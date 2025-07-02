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

        public async Task<List<AdminstrativeUnit>> GetAllChildrenByIdAsync(string id)
        {

            var children = await _appDBContext.AdministrativeUnits
                .Where(x => x.ParentId == id)
                .ToListAsync();
            return children;
        }

        public async Task<List<AdminstrativeUnit>> GetAllProvinces()
        {
            var provinces = await _appDBContext.AdministrativeUnits
                .Where(u => u.ParentId == null)
                .ToListAsync();

            return provinces;
        }

        public async Task<AdminstrativeUnit> GetByIdAsync(string id)
        {
            var result = await _appDBContext.AdministrativeUnits.FirstOrDefaultAsync(u => u.Id == id);

            return result == null ? null : result;
        }

        public async Task<List<string>> GetID(string entityType)
        {
            var id = _appDBContext.GetId(FlatAdministrativeUnit.ConvertType(entityType));
            return await Task.FromResult(new List<string> { id });
        }

        public async Task<bool> HasParentIsDeleted(string id)
        {
           
            var parent = await _appDBContext.AdministrativeUnits
                 .FromSqlRaw(@"SELECT * FROM getancestors({0})", id)
            .AsNoTracking()
            .ToListAsync();

            return parent.Any(x => x.IsDelete);

        }

        public async Task RemoveAsync(AdminstrativeUnit entity)
        {
            _appDBContext.Remove(entity);
        }


        public async Task<AdminstrativeUnit> UpdateLocationAsync(AdminstrativeUnit location)
        {
            _appDBContext.AdministrativeUnits.Update(location);

            return location;
        }
    }
}
