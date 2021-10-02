using Hestia.Application.Contracts.Contexts;
using Hestia.Application.Contracts.Repositories;
using Hestia.Domain.Documents;
using Hestia.Domain.Models;

namespace Hestia.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, ProductDocument>, IProductRepository
    {
        public ProductRepository(IDbContext context) : base(context)
        {
        }
    }
}
