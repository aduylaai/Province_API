using Province_API.Core.Domain.AdministrativeAggregate;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<AdminstrativeUnit>> GetAllAsync();
        
        Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity);

        Task RemoveAsync(AdminstrativeUnit entity);

        Task<AdminstrativeUnit> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID);

        Task<List<String>> GetID(AdminstrativeUnit entity); 
    }
}
