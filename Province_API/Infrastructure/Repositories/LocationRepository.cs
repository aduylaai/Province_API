using Microsoft.EntityFrameworkCore;
using Province_API.Application.DTOs;
using Province_API.Application.Interfaces;
using Province_API.Application.Interfaces.Repositories;
using Province_API.Domain.Entities;
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
        private List<AdministrativeUnitDTO>? administrativeUnitDTOs;

        public LocationRepository(IAppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            _administrativeUnits = _appDBContext.administrativeunits.ToListAsync().Result;
        }

        public List<AdministrativeUnitDTO> GetAll()
        {
            if (administrativeUnitDTOs == null)
            {
                administrativeUnitDTOs = _administrativeUnits.Select(unit => new AdministrativeUnitDTO
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    ParentId = unit.ParentId,
                    Type = unit.Type
                }).ToList();
            }
            return administrativeUnitDTOs;
        }
    }
}
