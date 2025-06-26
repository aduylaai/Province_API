using Province_API.Core.Domain.AdministrativeAggregate;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface ILocationService
    {
        List<AdminstrativeUnit> GetChildernAdministrativeUnits(string? parentID);
        // Additional methods can be defined here as needed
        AdminstrativeUnit GetAdministrativeUnit(string id);

        List<AdminstrativeUnit> GetAllProvinces();

        Task<AdminstrativeUnit> AddNewLocation(AdminstrativeUnit unit);

        Task<AdminstrativeUnit> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID);

        Task<AdminstrativeUnit> DeleteLocation(string? id);
    }
}
