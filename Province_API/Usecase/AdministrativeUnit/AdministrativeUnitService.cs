using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitService : IAdministrativeUnitUsecase
    {
        private readonly AdministrativeUnitCreate _create;
        private readonly AdministrativeUnitDelete _delete;
        private readonly AdministrativeUnitGet _get;
        private readonly AdministrativeUnitUpdate _update;

        public AdministrativeUnitService(AdministrativeUnitCreate create, AdministrativeUnitDelete delete, AdministrativeUnitGet get, AdministrativeUnitUpdate update)
        {
            _create = create;
            _delete = delete;
            _get = get;
            _update = update;
        }
        public Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID)
            => _create.AddNewLocation(pName, pType, pParentID);
        

        public Task<AdministrativeUnitDTO> DeleteLocationAsync(string pId)
            => _delete.DeleteLocation(pId);

        public Task<List<AdministrativeUnitDTO>> GetAllProvincesAsync()
            => _get.GetAllProvinces();

        public Task<AdministrativeUnitDTO> GetByIdAsync(string id)
            => _get.GetById(id);

        public Task<List<AdministrativeUnitDTO>> GetChildrenByIDAsync(string? id)
            => _get.GetChildrenByID(id);

        public Task<AdministrativeUnitDTO> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID)
            => _update.UpdateLocation(id,changeName, changeType, changeParentID);
    }
}
