using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Core.DTOs;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface ILocationService
    {
        Task<List<AdministrativeUnitDTO>> GetChildernAdministrativeUnits(string? parentID);
        Task<AdministrativeUnitDTO> GetAdministrativeUnit(string id);

        Task<List<AdministrativeUnitDTO>> GetAllProvinces();

        Task<AdministrativeUnitDTO> AddNewLocation(string pName, string pType, string? pParentID);

        Task<AdministrativeUnitDTO> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID);

        Task<AdminstrativeUnit> DeleteLocation(string? id);

        Task<AdministrativeUnitDTO> SoftDeleteById(string id);
    }
}
