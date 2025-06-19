using Province_API.Core.Application.DTOs;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface ILocationService
    {
        List<AdministrativeUnit> GetAdministrativeUnits(string? parentID);
        // Additional methods can be defined here as needed
        AdministrativeUnit GetAdministrativeUnitName(string id);

        List<AdministrativeUnit> GetProvinces();

    }
}
