using Hestia.Domain.Contracts;
using System.Threading.Tasks;

namespace Hestia.Application.Contracts.Repositories
{
    public interface IRepository<TEntity, TDocument>
        where TEntity : IEntity<TDocument>, new()
        where TDocument : class, IDocument
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}