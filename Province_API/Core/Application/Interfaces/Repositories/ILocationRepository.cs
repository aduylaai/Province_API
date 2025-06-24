using Province_API.Core.Domain.AdministrativeAggregate;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<AdminstrativeUnit>> GetAllAsync();
        
        Task addAsync(AdminstrativeUnit entity);

        Task removeAsync(AdminstrativeUnit entity);

        Task updateAsync(AdminstrativeUnit entity);
    }
}
