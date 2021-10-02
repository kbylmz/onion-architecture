using Hestia.Application.Contracts.Readers;
using Hestia.Domain.Documents;
using Hestia.Domain.Models;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hestia.Infrastructure.Readers
{
    public class ProductReader : IProductReader
    {
        private readonly IMongoCollection<ProductDocument> productCollection;

        public ProductReader(
            IMongoClient mongoClient,
            string dbName)
        {
            productCollection = mongoClient
                .GetDatabase(dbName)
                .GetCollection<ProductDocument>("Products");
        }

        public async Task<Product> GetById(Guid id)
        {
            var result = await productCollection.FindAsync(p => p.Id == id);

            var productDocument = result.FirstOrDefault();

            if (productDocument == null)
            {
                return null;
            }

            var product = new Product();
            product.Load(productDocument);

            return product;
        }
    }
}
