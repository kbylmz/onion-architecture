using System.Threading.Tasks;

namespace Hestia.Application.Contracts.Contexts
{
    public interface IDbContext
    {
        void Add(dynamic entity);
        void Update(dynamic entity);
        void Delete(dynamic entity);
        Task<bool> SaveChanges();
        void Dispose();
    }
}
