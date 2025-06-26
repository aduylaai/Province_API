using Province_API.Usecase.DTOs;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface IAdministrativeUnitService
    {
        Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID);

        Task<AdministrativeUnitDTO> DeleteLocationAsync(string pId);

        Task<List<AdministrativeUnitDTO>> GetAllProvincesAsync();

        Task<List<AdministrativeUnitDTO>> GetChildrenByIDAsync(string? id);

        Task<AdministrativeUnitDTO> GetByIdAsync(string id);

        Task<AdministrativeUnitDTO> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID);

    }
}
