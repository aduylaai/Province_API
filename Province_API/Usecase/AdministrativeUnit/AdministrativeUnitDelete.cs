using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitDelete
    {
        private ILocationService _locationService;

        public AdministrativeUnitDelete(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> DeleteLocationAsync(string id)
        {
            var unit = await _locationService.DeleteLocation(id);
            return new AdministrativeUnitDTO { Id = unit.Id ,Name = unit.Name, Type = unit.Type.ToString(), ParentId = unit.ParentId};
        }

        public async Task<AdministrativeUnitDTO> SoftDeleteLocationAsync(string id)
        {
            var unit = await _locationService.SoftDeleteById(id);
            return new AdministrativeUnitDTO { Id = unit.Id, Name = unit.Name, Type = unit.Type.ToString(), ParentId = unit.ParentId };
        }

    }
}
