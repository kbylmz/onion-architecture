using Hestia.Application.Contracts.Contexts;
using Hestia.Application.Contracts.Repositories;
using System.Threading.Tasks;

namespace Hestia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var result = await _context.SaveChanges();

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
