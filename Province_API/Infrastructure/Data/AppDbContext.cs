using Microsoft.EntityFrameworkCore;
using Province_API.Application.Interfaces;
using Province_API.Domain.Entities;

namespace Province_API.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDBContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdminstrativeUnit> administrativeunits { get; set;}

        
    }
}
