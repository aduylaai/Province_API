using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;

namespace Province_API.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDBContext;

        public LocationRepository(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity)
        {
            await _appDBContext.AddAsync(entity);
            return entity;
        }

        public async Task<List<AdminstrativeUnit>> GetAllAsync()
        {
            var administrativeUnits = await _appDBContext.AdministrativeUnits
                .Select(unit => new AdminstrativeUnit
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    ParentId = unit.ParentId,
                    Type = (Enums.AdministrativeUnitType)unit.Type
                })
                .ToListAsync();

            return administrativeUnits;
        }

        public async Task<List<string>> GetID(AdminstrativeUnit entity)
        {
            var id = _appDBContext.GetId(entity.Type);
            return await Task.FromResult(new List<string> { id });
        }

        public async Task RemoveAsync(AdminstrativeUnit entity)
        {
             _appDBContext.Remove(entity);
        }

        public async Task<AdminstrativeUnit> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID)
        {
            var location = await _appDBContext.AdministrativeUnits.FindAsync(id);

            if (location == null)
                throw new Exception($"Cannot find administrative unit with ID: {id}");

            location.Name = changeName;
            location.Type = Enum.Parse<Enums.AdministrativeUnitType>(changeType);
            location.ParentId = changeParentID;

            _appDBContext.AdministrativeUnits.Update(location);

            return location;
        }
    }
}
