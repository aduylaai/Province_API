using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Repositories;
using Province_API.Infrastructure.Utils;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface ILocationRepository : IGenericRepository<AdminstrativeUnit>
    {
        //Task<List<AdminstrativeUnit>> GetAllAsync();

        //Task<AdminstrativeUnit> GetByIdAsync(string id);
        
        //Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity);

        Task RemoveAsync(AdminstrativeUnit entity);

        Task<List<String>> GetID(string entityType);

        Task<QueryableWrapper<AdminstrativeUnit>> GetAllChildrenByIdAsync(string id);

        Task<QueryableWrapper<AdminstrativeUnit>> GetAllProvinces();

        Task<bool> IsAvailableAsync(string id);
        Task<bool> HasParentIsDeleted(string id);
    }
}
