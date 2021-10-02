using Hestia.Domain.Documents;
using Hestia.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Hestia.Application.Contracts.Readers
{
    public interface IProductReader
    {
        Task<Product> GetById(Guid id);
    }
}
