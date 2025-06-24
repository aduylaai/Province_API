using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeDelete
    {
        private ILocationService _locationService;

        public AdministrativeDelete(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> DeleteLocation(string id)
        {
            var unit = await _locationService.DeleteLocation(id);
            return new AdministrativeUnitDTO { Id = unit.Id ,Name = unit.Name, Type = unit.Type.ToString(), ParentId = unit.ParentId};
        }

    }
}
