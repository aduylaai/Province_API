using Province_API.Application.DTOs;
using Province_API.Application.Interfaces.Repositories;
using Province_API.Application.Interfaces.Services;
using Province_API.Domain.Entities;

namespace Province_API.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly List<AdministrativeUnit_DTO> _allUnit;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            _allUnit = _locationRepository.GetAll();
        }

        public List<AdministrativeUnit_DTO> GetAdministrativeUnit(string? parentID)
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

        public AdministrativeUnit_DTO GetAdministrativeUnitName(string id) => _allUnit
            .FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"Administrative unit with ID {id} not found."); 


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
