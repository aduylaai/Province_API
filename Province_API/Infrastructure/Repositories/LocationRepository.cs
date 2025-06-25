using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Utils;

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
                .ToListAsync();

            return administrativeUnits;
        }

        public async Task<List<string>> GetID(string entityType)
        {
            var id = _appDBContext.GetId(FlatAdministrativeUnit.ConvertType(entityType));
            return await Task.FromResult(new List<string> { id });
        }

        public async Task RemoveAsync(AdminstrativeUnit entity)
        {
             _appDBContext.Remove(entity);
        }

        public async Task<AdminstrativeUnit> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID)
        {
            // Quang len services
            var location = await _appDBContext.AdministrativeUnits.FindAsync(id);

            if (location == null)
                throw new Exception($"Cannot find administrative unit with ID: {id}");

            location.Name = changeName;

            //TODO: Check the type => GetID => Gain new id...
            
            location.Type = Enum.Parse<Enums.AdministrativeUnitType>(changeType);
            location.ParentId = changeParentID;

            _appDBContext.AdministrativeUnits.Update(location);

            return location;
        }
    }
}
