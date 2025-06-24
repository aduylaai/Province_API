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

        //public async Task AddAsync(AdminstrativeUnit entity, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        await _appDBContext.AdministrativeUnits.AddAsync(entity, cancellationToken);
        //        await _appDBContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public async Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity)
        {
            await _appDBContext.AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
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
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<AdminstrativeUnit> UpdateAsync(AdminstrativeUnit entity)
        {
            _appDBContext.Update(entity);
            await _appDBContext.SaveChangesAsync();
            return entity;
        }


    }
}
