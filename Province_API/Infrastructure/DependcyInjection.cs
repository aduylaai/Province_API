using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Province_API.Application.Interfaces;
using Province_API.Application.Interfaces.Repositories;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Repositories;

namespace Province_API.Infrastructure
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString) {

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IAppDBContext>(provider => provider.GetRequiredService<AppDbContext>());

            // Fix JsonLocationRepository (Static Json file) or LocationRepository (DB)
            services.AddSingleton<ILocationRepository, JsonLocationRepository>();
            return services;
        }

    }
}
