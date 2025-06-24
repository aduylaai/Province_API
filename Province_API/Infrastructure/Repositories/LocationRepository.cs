using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Models;
using Province_API.Infrastructure.Utils;
using Province_API.Core.Domain.AdministrativeAggregate;
using System.Text.Json;
using System.Threading.Tasks;
using Province_API.Infrastructure.Data;

namespace Province_API.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDBContext;
        private readonly List<AdminstrativeUnit> _administrativeUnits;
        private List<AdminstrativeUnit>? administrativeUnitDTOs;


        public LocationRepository(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task addAsync(AdminstrativeUnit entity,CancellationToken cancellationToken)
        {
            try
            {
                await _appDBContext.AdministrativeUnits.AddAsync(entity, cancellationToken);
                await _appDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task addAsync(AdminstrativeUnit entity)
        {
            await _appDBContext.AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
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

        public Task removeAsync(AdminstrativeUnit entity)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(AdminstrativeUnit entity)
        {
            throw new NotImplementedException();
        }
    }
}
