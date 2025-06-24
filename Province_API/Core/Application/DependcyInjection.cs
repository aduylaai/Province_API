using Microsoft.Extensions.DependencyInjection;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Core.Application.Services;

namespace Province_API.Core.Application
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
