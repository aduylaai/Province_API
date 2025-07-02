using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.DTOs;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Core.Application.Interfaces;
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
        public List<AdminstrativeUnit> GetChildernAdministrativeUnits(string? parentID)
        {

            if (parentID == null)
            {
                return GetAllProvinces();
            }
            else
            {
                var children = _unitOfWork.LocationRepository.GetAllChildrenByIdAsync(parentID).Result;
                return children;
            }
        }
        public AdminstrativeUnit GetAdministrativeUnit(string id)
        {

            var unit = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;

            if (unit.ParentId != null && _unitOfWork.LocationRepository.HasParentIsDeleted(id).Result)
            {
                return new AdminstrativeUnit();
            }

            return unit ?? null;
        }
        public List<AdminstrativeUnit> GetAllProvinces()
        {
            return _unitOfWork.LocationRepository.GetAllProvinces().Result;
        }

        public async Task<AdminstrativeUnit> AddNewLocation(AdminstrativeUnit unit)
        {
            var ids = await _unitOfWork.LocationRepository.GetID(unit.Type.ToString());
            string id = ids.FirstOrDefault() ?? string.Empty;

            unit.UpdateID(id);

            var newUnit = await _unitOfWork.LocationRepository.AddAsync(unit);
            _unitOfWork.SaveChangesAsync();

            return newUnit;
        }


        public async Task<AdminstrativeUnit> DeleteLocation(string? id)
        {
            var unit = GetAdministrativeUnit(id);

            var children = GetChildernAdministrativeUnits(id);
            foreach (var child in children)
            {
                await DeleteLocation(child.Id);
            }

            await _unitOfWork.LocationRepository.RemoveAsync(unit);
            _unitOfWork.SaveChangesAsync();
            return unit;
        }

        public async Task<AdminstrativeUnit> UpdateLocationAsync(string id, string changeName, string changeType, string? changeParentID)
        {
            var location = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;

            AdministrativeUnitType changedType = Enum.Parse<Enums.AdministrativeUnitType>(changeType);
            location.UpdateAdministrativeUnit(changeName, changedType, changeParentID);
            
            var changedLocation = await _unitOfWork.LocationRepository.UpdateLocationAsync(location);
            _unitOfWork.SaveChangesAsync();
            return changedLocation;
        }

        public async Task<AdminstrativeUnit> SoftDeleteById(string id)
        {
            var unit = _unitOfWork.LocationRepository.GetByIdAsync(id).Result;

            //var children = GetChildernAdministrativeUnits(id);
            //foreach (var child in children)
            //{
            //    await SoftDeleteById(child.Id);
            //}

            unit.MarkAsDelete();
            await _unitOfWork.LocationRepository.UpdateLocationAsync(unit);
            _unitOfWork.SaveChangesAsync();
            return unit;

        }
    }
}
