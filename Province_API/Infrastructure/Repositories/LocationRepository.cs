using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.DTOs;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Models;
using Province_API.Infrastructure.Utils;
using System.Text.Json;
using System.Threading.Tasks;

namespace Province_API.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IAppDBContext _appDBContext;
        private readonly List<AdminstrativeUnit> _administrativeUnits;
        private List<AdministrativeUnit>? administrativeUnitDTOs;


        public LocationRepository(IAppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<List<AdministrativeUnit>> GetAllAsync()
        {
            var administrativeUnits = await _appDBContext.AdministrativeUnits
                .Select(unit => new AdministrativeUnit
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    ParentId = unit.ParentId,
                    Type = unit.Type.ToString()
                })
                .ToListAsync();

            return administrativeUnits;
        }
    }
}
