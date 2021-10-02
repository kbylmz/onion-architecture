using System;
using System.Threading.Tasks;

namespace Hestia.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
