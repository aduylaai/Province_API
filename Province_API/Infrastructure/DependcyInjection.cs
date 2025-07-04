using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Repositories;
using Province_API.Infrastructure.Utils;

namespace Province_API.Infrastructure
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            //services.AddScoped<IAppDBContext>(provider => provider.GetRequiredService<AppDbContext>());

            // Fix JsonLocationRepository (Static Json file) or LocationRepository (DB)
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(provider => new JsonLoader());
            services.AddScoped<JsonSeeder>();
            return services;
        }

    }
}
