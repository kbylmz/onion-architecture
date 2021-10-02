using Hestia.Application.Contracts.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hestia.Infrastructure.DbContexts
{
    public class MongoContext : IDbContext
    {
        private IMongoClient mongoClient;
        private IClientSessionHandle session;
        //private IDomainEventDispatcher eventDispatcher;
        private readonly List<Func<Task>> commands;
        private string dbName;

        //public MongoContext(string connectionString, string dbName, IDomainEventDispatcher eventDispatcher)
        //{
        //    commands = new List<Func<Task>>();
        //    this.eventDispatcher = eventDispatcher;
        //    this.dbName = dbName;
        //    mongoClient = new MongoClient(connectionString);
        //}

        public MongoContext(IMongoClient mongoClient,string dbName)
        {
            commands = new List<Func<Task>>();
            this.dbName = dbName;
            this.mongoClient = mongoClient;
        }

        public void Add(dynamic entity)
        {
            var document = entity.ToDocument();
            document.Version = 1;

            document.CreatedAt = DateTime.Now;
            document.UpdatedAt = DateTime.Now;

            var collection = GetCollection(entity.GetType());
            var wrap = new BsonDocumentWrapper(document);
            commands.Add(() => collection.InsertOneAsync(wrap));
        }

        public void Update(dynamic entity)
        {
            var document = entity.ToDocument();

            int initialVersion = document.Version;
            document.Version += 1;
            document.UpdatedAt = DateTime.Now;

            var collection = GetCollection(document.GetType());
            var wrap = new BsonDocumentWrapper(document);
            commands.Add(async () =>
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("_id", document.Id) & builder.Eq("Version", initialVersion);

                await collection.ReplaceOneAsync(filter, wrap);
            });
        }

        public void Delete(dynamic entity)
        {
            var document = entity.ToDocument();
            var collection = GetCollection(document.GetType());

            commands.Add(async () =>
            {
                await collection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", document.Id));
            });
        }

        public async Task<bool> SaveChanges()
        {
            using (session = await mongoClient.StartSessionAsync())
            {
                session.StartTransaction();

                var commandTasks = commands.Select(c => c());
                await Task.WhenAll(commandTasks);

                await session.CommitTransactionAsync();

                //var domainEvents = trackedEntities.ToList().SelectMany<dynamic, IEvent>(entity => entity.UncommittedEvents).ToList();
                //await eventDispatcher.PublishEvents(domainEvents);
            }

            return commands.Count > 0;
        }

        #region | PRIVATE METHODS |
        private IMongoCollection<BsonDocument> GetCollection(Type documentType)
        {
            return mongoClient
                .GetDatabase(dbName)
                .GetCollection<BsonDocument>($"{documentType.Name}s");
        }
        #endregion
        public void Dispose()
        {
             GC.SuppressFinalize(this);
        }
    }
}
