using Microsoft.Extensions.DependencyInjection;
using Province_API.Application.Interfaces.Repositories;

namespace Province_API.Infrastructure
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) { 
        
            services.AddSingleton<ILocationRepository, Location.Infrastructure.Repositories.JsonLocationRepository>();
            // Database add here if needed
            return services;
        }

    }
}
