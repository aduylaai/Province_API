using Province_API.Core.Application.Interfaces;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Infrastructure.Repositories;

namespace Province_API.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ILocationRepository locationRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ILocationRepository LocationRepository
        {
            get
            {

                if (locationRepository == null)
                {
                    this.locationRepository = new LocationRepository(_appDbContext);
                }
                return locationRepository;
            }
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
