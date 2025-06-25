using Province_API.Usecase.DTOs;

namespace Province_API.Core.Application.Interfaces.Services
{
    public interface IAdministrativeUnitService
    {
        Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID);

        Task<AdministrativeUnitDTO> DeleteLocationAsync(string pId);

        Task<List<AdministrativeUnitDTO>> GetAllUnitAsync();

        Task<List<AdministrativeUnitDTO>> GetChildrenByIDAsync(string? id);

        Task<AdministrativeUnitDTO> GetByIdAsync(string id);

    }
}
