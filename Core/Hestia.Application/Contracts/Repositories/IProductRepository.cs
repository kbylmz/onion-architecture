using Hestia.Application.Contracts.Repositories;
using Hestia.Domain.Documents;
using Hestia.Domain.Models;

namespace Hestia.Application.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product, ProductDocument>
    {
    }
}
