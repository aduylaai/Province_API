using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Utils;
using System.Text.RegularExpressions;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdminstrativeUnit> AdministrativeUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminstrativeUnit>(entity =>
            {
                //entity.HasQueryFilter(x=>!x.IsDelete);
                entity.ToTable("administrative_unit");
                entity.Property(e => e.Type)
                       .HasConversion(
                            v => v.GetEnumMemberValue(),
                            v => EnumHelpers.ParseEnumMemberValue<AdministrativeUnitType>(v)
                            );
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parentId");
                entity.Property(e => e.Type).HasColumnName("type");
            });
        }

    }
}
