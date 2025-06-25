using Province_API.Core.Application.Interfaces.Repositories;

namespace Province_API.Core.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILocationRepository LocationRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
