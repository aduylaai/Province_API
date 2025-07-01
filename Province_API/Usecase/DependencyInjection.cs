using Province_API.Core.Application.Interfaces.Services;
using Province_API.Core.Application.Services;
using Province_API.Usecase.AdministrativeUnit;

namespace Province_API.Usecase
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddUseCase(this IServiceCollection service)
        {

            service.AddScoped<AdministrativeUnitGet>();
            service.AddScoped<AdministrativeUnitCreate>();
            service.AddScoped<AdministrativeUnitDelete>();
            service.AddScoped<AdministrativeUnitUpdate>();
            return service;
        }
    }
}
