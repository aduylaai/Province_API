using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;
using Province_API.Core.Domain.AdministrativeAggregate;

namespace Province_API.Core.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public List<AdminstrativeUnit> GetAdministrativeUnits(string? parentID)
        {
            var _allUnit = _locationRepository.GetAllAsync().Result;
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
        public AdminstrativeUnit GetAdministrativeUnit(string id) => _locationRepository.GetAllAsync().Result
            .FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException($"Administrative unit with ID {id} not found.");
        public List<AdminstrativeUnit> GetProvinces() => _locationRepository.GetAllAsync().Result
            .Where(x => x.ParentId == null)
            .ToList();

        public async Task<AdminstrativeUnit> AddNewLocation(AdminstrativeUnit unit) {
            var ids = await _locationRepository.GetID(unit);
            string id = ids.FirstOrDefault() ?? string.Empty;

            unit.Id = id;

            var newUnit = await _locationRepository.AddAsync(unit);

            return newUnit;
        }

        public Task<AdminstrativeUnit> UpdateLocation(AdminstrativeUnit unit)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminstrativeUnit> DeleteLocation(string? id)
        {
            var unit = GetAdministrativeUnit(id);
            await _locationRepository.RemoveAsync(unit);
            return unit;
        }
    }
}
