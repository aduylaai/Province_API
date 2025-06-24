using Province_API.Core.Domain.AdministrativeAggregate;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface ILocationService
    {
        List<AdminstrativeUnit> GetAdministrativeUnits(string? parentID);
        // Additional methods can be defined here as needed
        AdminstrativeUnit GetAdministrativeUnit(string id);

        List<AdminstrativeUnit> GetProvinces();

    }
}
