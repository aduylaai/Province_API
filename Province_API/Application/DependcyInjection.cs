using Microsoft.Extensions.DependencyInjection;
using Province_API.Application.Interfaces;
using Province_API.Application.Usecase;

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
