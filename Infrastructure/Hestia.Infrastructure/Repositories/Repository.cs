using Hestia.Application.Contracts.Contexts;
using Hestia.Application.Contracts.Repositories;
using Hestia.Domain.Contracts;
using System.Threading.Tasks;

namespace Hestia.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TDocument> : IRepository<TEntity, TDocument>
        where TEntity : IEntity<TDocument>, new()
        where TDocument : class, IDocument
    {
        protected readonly IDbContext _context;

        protected Repository(IDbContext context)
        {
            _context = context;
        }

        public virtual Task Add(TEntity entity)
        {
            _context.Add(entity);

            return Task.CompletedTask;
        }

        public virtual Task Update(TEntity entity)
        {
            _context.Update(entity);

            return Task.CompletedTask;
        }

        public virtual Task Delete(TEntity entity)
        {
            _context.Delete(entity);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
