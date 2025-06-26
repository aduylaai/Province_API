using Province_API.Core.Application.Interfaces.Services;
using Province_API.Infrastructure.Utils;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitGet
    {
        private readonly ILocationService _locationService;

        public AdministrativeUnitGet(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> GetById(string id)
        {
            var unit = await Task.Run(() => _locationService.GetAdministrativeUnit(id));
            if (unit != null)
            {
                return new AdministrativeUnitDTO(unit.Id, unit.Name, EnumHelpers.GetEnumMemberValue(unit.Type), unit.ParentId);
            }
            else
            {
                return new AdministrativeUnitDTO();
            }
        }

        public async Task<List<AdministrativeUnitDTO>> GetChildrenByID(string? id)
        {
            var children = await Task.Run(() => _locationService.GetChildernAdministrativeUnits(id));

            List<AdministrativeUnitDTO> _children = new List<AdministrativeUnitDTO>();
            foreach (var child in children)
            {
                _children.Add(new AdministrativeUnitDTO(child.Id, child.Name, EnumHelpers.GetEnumMemberValue(child.Type), child.ParentId));
            }
            return _children;
        }

        public async Task<List<AdministrativeUnitDTO>> GetAllProvinces()
        {
            var children = await Task.Run(() => _locationService.GetChildernAdministrativeUnits(null));

            List<AdministrativeUnitDTO> _children = new List<AdministrativeUnitDTO>();
            foreach (var child in children)
            {
                _children.Add(new AdministrativeUnitDTO(child.Id, child.Name, EnumHelpers.GetEnumMemberValue(child.Type), child.ParentId));
            }
            return _children;
        }
    }
}
