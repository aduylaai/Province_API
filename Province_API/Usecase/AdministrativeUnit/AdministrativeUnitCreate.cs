using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Utils;
using Province_API.Usecase.DTOs;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Usecase.AdministrativeUnit
{
    public class AdministrativeUnitCreate
    {
        private readonly ILocationService _locationService;
        public AdministrativeUnitCreate(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AdministrativeUnitDTO> AddNewLocation(string pName, string pType, string? pParentID)
        {
            var type = FlatAdministrativeUnit.ConvertType(pType);

            AdminstrativeUnit unit = new AdminstrativeUnit
            {
                Name = pName,
                Type = type,
                ParentId = pParentID
            };

            var newUnit = await _locationService.AddNewLocation(unit);

            return new AdministrativeUnitDTO(newUnit.Id, newUnit.Name, newUnit.Type.ToString(), newUnit.ParentId);
        }
    }
}
