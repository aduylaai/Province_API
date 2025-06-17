using Microsoft.Extensions.DependencyInjection;
using Province_API.Application.Interfaces.Services;
using Province_API.Application.Services;

namespace Province_API.Application
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service) {

            service.AddScoped<ILocationService, LocationService>();
            //Add other application services here if needed
            return service;
        }
    }
}
