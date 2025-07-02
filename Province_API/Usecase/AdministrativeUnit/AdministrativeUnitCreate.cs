using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Utils;
using Province_API.Core.DTOs;
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

        public async Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID)
        {
            //var type = FlatAdministrativeUnit.ConvertType(pType);

            //var unit = new AdministrativeUnitBuilder()
            //                .withName(pName)
            //                .withType(type)
            //                .withParentId(pParentID)
            //                .Build();

            //var newUnit = await _locationService.AddNewLocation(unit);
            
            //return new AdministrativeUnitDTO(newUnit.Id, newUnit.Name, newUnit.Type.ToString(), newUnit.ParentId);
            throw new NotImplementedException();
        }
    }
}
