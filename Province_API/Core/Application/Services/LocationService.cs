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
        public async Task<List<AdministrativeUnitDTO>> GetChildernAdministrativeUnits(string? parentID)
        {
            if (parentID == null)
            {
                return await Task.FromResult(GetAllProvinces()).Result;
            }
            else
            {
                var children = _unitOfWork.LocationRepository.GetAllChildrenByIdAsync(parentID).Result;
                List<AdministrativeUnitDTO> dtos = new List<AdministrativeUnitDTO>();
                foreach (var child in children)
                {
                    dtos.Add(ConvertToDTO(child));
                }
                return dtos;
            }
        }
        public async Task<AdministrativeUnitDTO> GetAdministrativeUnit(string id)
        {

            var unit = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;

            if (unit.ParentId != null && _unitOfWork.LocationRepository.HasParentIsDeleted(id).Result || unit.IsDelete)
            {
                return null;
            }

            return ConvertToDTO(unit) ?? null;
        }
        public async Task<List<AdministrativeUnitDTO>> GetAllProvinces()
        {
            var allProvince = _unitOfWork.LocationRepository.GetAllProvinces().Result;
            List<AdministrativeUnitDTO> dtos = new List<AdministrativeUnitDTO>();
            foreach (var province in allProvince) { 
              dtos.Add(ConvertToDTO(province));
            }
            return dtos;
        }
        //--- CREATE FUNCTION
         public async Task<AdministrativeUnitDTO> AddNewLocation(string pName, string pType, string? pParentID)
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

            var newUnit = await _unitOfWork.LocationRepository.AddAsync(unit);
            _unitOfWork.SaveChangesAsync();

            
            return ConvertToDTO(newUnit);
        }


        public async Task<AdminstrativeUnit> DeleteLocation(string? id)
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
            var location = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;

            AdministrativeUnitType changedType = Enum.Parse<Enums.AdministrativeUnitType>(changeType);
            location.UpdateAdministrativeUnit(changeName, changedType, changeParentID);

            var changedLocation = await _unitOfWork.LocationRepository.UpdateLocationAsync(location);
            _unitOfWork.SaveChangesAsync();


            return ConvertToDTO(changedLocation);
        }

        public async Task<AdministrativeUnitDTO> SoftDeleteById(string id)
        {
            var unit = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;
            
            unit.MarkAsDelete();
            await _unitOfWork.LocationRepository.UpdateLocationAsync(unit);
            _unitOfWork.SaveChangesAsync();
            return ConvertToDTO(unit);

        }

        private AdministrativeUnitDTO ConvertToDTO(AdminstrativeUnit unit) {
            return new AdministrativeUnitDTO(unit.Id, unit.Name, unit.Type.ToString(), unit.ParentId);
        }
    }
}
