using Province_API.Application.DTOs;

namespace Province_API.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        List<AdministrativeUnitDTO> GetAll();

    }
}
