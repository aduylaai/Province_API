using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitUseCase
    {
        private readonly ILocationService _locationService;

        public AdministrativeUnitUseCase(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> GetById(string id)
        {
            var unit = _locationService.GetAdministrativeUnit(id);
            if (unit != null)
            {
                return new AdministrativeUnitDTO(unit.Id, unit.Name, unit.Type.ToString(), unit.ParentId);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<AdministrativeUnitDTO>> GetChildrenByID(string? id)
        {
            var children = _locationService.GetAdministrativeUnits(id);
            if (children != null)
            {
                List<AdministrativeUnitDTO> _children = new List<AdministrativeUnitDTO>();
                foreach (var child in children) {
                    _children.Add(new AdministrativeUnitDTO(child.Id,child.Name,child.Type.ToString(),child.ParentId));
                }
                return _children;
            }

            return new List<AdministrativeUnitDTO>();
        }

        public async Task<List<AdministrativeUnitDTO>> GetAllUnit()
        {
            var children = _locationService.GetAdministrativeUnits(null);
            if (children != null)
            {
                List<AdministrativeUnitDTO> _children = new List<AdministrativeUnitDTO>();
                foreach (var child in children)
                {
                    _children.Add(new AdministrativeUnitDTO(child.Id, child.Name, child.Type.ToString(), child.ParentId));
                }
                return _children;
            }

            return new List<AdministrativeUnitDTO>();
        }
    }
}
