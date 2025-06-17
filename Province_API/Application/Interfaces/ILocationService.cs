using Province_API.Application.DTOs;

namespace Province_API.Application.Interfaces
{
    public interface ILocationService
    {
        List<AdministrativeUnit_DTO> GetAdministrativeUnit(string? parentID);
    }
}
