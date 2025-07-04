using Mapster;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Core.DTOs;
using Province_API.Infrastructure.Utils;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AdministrativeUnitDTO>> GetChildernAdministrativeUnitsAsync(string? parentID)
        {
            if (parentID == null || await _unitOfWork.LocationRepository.IsAvailableAsync(parentID) == false) throw new Exception("Not fouund!");
            else
            {
                var childrenWrapper = await _unitOfWork.LocationRepository.GetAllChildrenByIdAsync(parentID);
                var children = await childrenWrapper.ToListAsync();
                var dtos = children.Adapt<List<AdministrativeUnitDTO>>();
                return dtos;
            }
        }
        public async Task<AdministrativeUnitDTO> GetAdministrativeUnitAsync(string id)
        {

            var unit = await _unitOfWork.LocationRepository.GetByIdAsync(id);

            if (unit.IsDelete || unit.ParentId != null && await _unitOfWork.LocationRepository.HasParentIsDeleted(id))
            {
                return null;
            }

            var unitDto = unit.Adapt<AdministrativeUnitDTO>();

            return unitDto ?? null;
        }
        public async Task<List<AdministrativeUnitDTO>> GetAllProvincesAsync()
        {
            var allProvinceQuery = await _unitOfWork.LocationRepository.GetAllProvinces();
            var allProvince = allProvinceQuery.ToListAsync();

            var dtos = allProvince.Adapt<List<AdministrativeUnitDTO>>();
            return dtos;
        }
        //--- CREATE FUNCTION
        public async Task<AdministrativeUnitDTO> AddNewLocationAsync(string pName, string pType, string? pParentID)
        {
            var type = FlatAdministrativeUnit.ConvertType(pType);

            var unit = new AdministrativeUnitBuilder()
                            .withName(pName)
                            .withType(type)
                            .withParentId(pParentID)
                            .Build();

            var ids = await _unitOfWork.LocationRepository.GetID(unit.Type.ToString());
            string id = ids.FirstOrDefault() ?? string.Empty;

            unit.UpdateID(id);

            await _unitOfWork.LocationRepository.AddAsync(unit);
            await _unitOfWork.SaveChangesAsync();

            return unit.Adapt<AdministrativeUnitDTO>();
        }


        public async Task<AdminstrativeUnit> DeleteLocationAsync(string? id)
        {
            //var unit = GetAdministrativeUnit(id);

            //var children = GetChildernAdministrativeUnits(id);
            //foreach (var child in children)
            //{
            //    await DeleteLocation(child.Id);
            //}

            //await _unitOfWork.LocationRepository.RemoveAsync(unit);
            //_unitOfWork.SaveChangesAsync();
            //return unit;
            throw new NotImplementedException();
        }

        public async Task<AdministrativeUnitDTO> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID)
        {
            var location= await _unitOfWork.LocationRepository.GetByIdAsync(id);

            AdministrativeUnitType changedType = Enum.Parse<Enums.AdministrativeUnitType>(changeType);
            location.UpdateAdministrativeUnit(changeName, changedType, changeParentID);

            var changedLocation = await _unitOfWork.LocationRepository.UpdateAsync(location);
            await _unitOfWork.SaveChangesAsync();


            return changedLocation.Adapt<AdministrativeUnitDTO>();
        }

        public async Task<AdministrativeUnitDTO> SoftDeleteByIdAsync(string id)
        {
            var unit = await _unitOfWork.LocationRepository.GetByIdAsync(id);

            unit.MarkAsDelete();
            await _unitOfWork.LocationRepository.UpdateAsync(unit);
            await _unitOfWork.SaveChangesAsync();
            return unit.Adapt<AdministrativeUnitDTO>();

        }
    }
}
