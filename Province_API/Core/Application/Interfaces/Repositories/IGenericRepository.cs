using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Repositories;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T?>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
