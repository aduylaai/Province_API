using Province_API.Application.DTOs;

namespace Province_API.Application.Interfaces.Services
{
    public interface ILocationService
    {
        List<AdministrativeUnitDTO> GetAdministrativeUnits(string? parentID);
        // Additional methods can be defined here as needed
        AdministrativeUnitDTO GetAdministrativeUnitName(string id);

        List<AdministrativeUnitDTO> GetProvinces();

    }
}
