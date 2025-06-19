using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Domain.Entities;

namespace Province_API.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDBContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdminstrativeUnit> AdministrativeUnits { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminstrativeUnit>(entity =>
            {
                entity.Property(e => e.Type)
                      .HasConversion<string>(); 
            });
        }

    }
}
