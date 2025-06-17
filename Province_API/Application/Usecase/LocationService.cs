using Province_API.Application.DTOs;
using Province_API.Application.Interfaces;
using Province_API.Domain.Entities;

namespace Province_API.Application.Usecase
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<AdministrativeUnit_DTO> GetAdministrativeUnit(string? parentID)
        {
            var all = _locationRepository.GetAll();
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
