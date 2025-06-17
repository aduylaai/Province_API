using Microsoft.Extensions.DependencyInjection;
using Province_API.Application.Interfaces;

namespace Province_API.Infrastructure
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) { 
        
            services.AddScoped<ILocationRepository, Location.Infrastructure.Repositories.JsonRepository>();
            // Database add here if needed
            return services;
        }

    }
}
