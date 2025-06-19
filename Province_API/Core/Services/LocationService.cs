using Province_API.Core.Application.DTOs;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;

namespace Province_API.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly List<AdministrativeUnit> _allUnit;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            _allUnit = _locationRepository.GetAll();
        }

        public List<AdministrativeUnit> GetAdministrativeUnits(string? parentID)
        {
            if (parentID == null)
            {
                return _allUnit
                   .Where(x => x.ParentId == null)
                   .ToList();
            }
            else
            {
                return _allUnit
                    .Where(x => x.ParentId == parentID).ToList();
            }
        }

        public AdministrativeUnit GetAdministrativeUnitName(string id) => _allUnit
            .FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"Administrative unit with ID {id} not found.");

        public List<AdministrativeUnit> GetProvinces() => _allUnit
            .Where(x => x.ParentId == null)
            .ToList();



        // ---

        // Method to change the administrative units to DTOs
        //private AdministrativeUnit_DTO ToDto(AdminstrativeUnit u) => new()
        //{
        //    Id = u.Id,
        //    Name = u.Name,
        //    Type = u.Type
        //};
        // --
    }
}
