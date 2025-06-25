using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitUpdate
    {
        private readonly ILocationService _locationService;

        public AdministrativeUnitUpdate(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> UpdateLocation(string id, string changeName, string changeType, string? changeParentID)
        {
            var unit = await _locationService.UpdateLocationAsync(id, changeName,changeType,changeParentID);

            return new AdministrativeUnitDTO(unit.Id,unit.Name,unit.Type.ToString(), unit.ParentId);
        }
    }
}
