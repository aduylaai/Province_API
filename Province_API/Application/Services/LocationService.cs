using Province_API.Application.DTOs;
using Province_API.Application.Interfaces.Repositories;
using Province_API.Application.Interfaces.Services;
using Province_API.Domain.Entities;

namespace Province_API.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private List<AdministrativeUnit_DTO> all;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            all = _locationRepository.GetAll();
            if (all == null || all.Count == 0)
            {
                throw new Exception("Cannot access database, please re-check!");
            }
        }

        public List<AdministrativeUnit_DTO> GetAdministrativeUnit(string? parentID)
        {
            if (parentID == null)
            {
                return all
                   .Where(x => x.ParentId == null)
                   .ToList();
            }
            else
            {
                return all
                    .Where(x => x.ParentId == parentID).ToList();
            }
        }


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
