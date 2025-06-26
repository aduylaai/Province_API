using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Utils;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<AdminstrativeUnit>> GetAllAsync();

        Task<AdminstrativeUnit> GetByIdAsync(string id);
        
        Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity);

        Task RemoveAsync(AdminstrativeUnit entity);

        Task<AdminstrativeUnit> UpdateLocationAsync(AdminstrativeUnit location);

        Task<List<String>> GetID(string entityType);

        Task<List<AdminstrativeUnit>> GetAllChildrenByIdAsync(string id);

        Task<List<AdminstrativeUnit>> GetAllProvinces();
    }
}
