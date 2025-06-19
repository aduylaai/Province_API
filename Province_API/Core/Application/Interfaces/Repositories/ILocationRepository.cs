using Province_API.Core.Application.DTOs;

namespace Province_API.Core.Application.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        Task<List<AdministrativeUnit>> GetAllAsync();
    }
}
