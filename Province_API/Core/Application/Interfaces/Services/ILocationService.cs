using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Core.DTOs;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface ILocationService
    {
        Task<List<AdministrativeUnitDTO>> GetChildernAdministrativeUnitsAsync(string? parentID);
        Task<AdministrativeUnitDTO> GetAdministrativeUnitAsync(string id);

        Task<List<AdministrativeUnitDTO>> GetAllProvincesAsync();

        Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID);

        Task<AdministrativeUnitDTO> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID);

        Task<AdminstrativeUnit> DeleteLocationAsync(string? id);

        Task<AdministrativeUnitDTO> SoftDeleteByIdAsync(string id);
    }
}
