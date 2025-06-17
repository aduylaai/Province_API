using Province_API.Application.DTOs;

namespace Province_API.Application.Interfaces
{
    public interface ILocationService
    {
        List<AdministrativeUnit_DTO> GetProvinces();
        List<AdministrativeUnit_DTO> GetDistricts(string provinceId);
        List<AdministrativeUnit_DTO> GetWards(string districtId);

    }
}
