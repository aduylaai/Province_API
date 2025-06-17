using Province_API.Application.DTOs;

namespace Province_API.Application.Interfaces
{
    public interface ILocationRepository
    {

        List<AdministrativeUnit_DTO> GetAll();

    }
}
