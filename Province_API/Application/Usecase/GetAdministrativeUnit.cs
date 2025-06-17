using Province_API.Application.DTOs;
using Province_API.Application.Interfaces;
using Province_API.Domain.Entities;

namespace Province_API.Application.Usecase
{
    public class GetAdministrativeUnit : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public GetAdministrativeUnit(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<AdministrativeUnit_DTO> GetProvinces()
        {
            var all = _locationRepository.GetAll();
            return all
               .Where(x => x.ParentId == null)
               .ToList();
        }

        public List<AdministrativeUnit_DTO> GetDistricts(string provinceId)
        {
            var all = _locationRepository.GetAll();
            return all
                .Where(x => x.ParentId == provinceId)
                .ToList();
        }

        public List<AdministrativeUnit_DTO> GetWards(string districtId)
        {
            var all = _locationRepository.GetAll();
            return all
                .Where(x => x.ParentId == districtId)
                .ToList();
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
