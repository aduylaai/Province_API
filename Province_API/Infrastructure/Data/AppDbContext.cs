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

        private Dictionary<string, int> GetLatestIDsByPrefix()
        {
            var result = new Dictionary<string, int>();

            var ids = AdministrativeUnits
                .Select(x => x.Id)
                .ToList();

            foreach (var id in ids)
            {
                var match = Regex.Match(id, @"^([a-zA-Z]+)(\d+)$"); // Tách prefix và số

                if (match.Success)
                {
                    var prefix = match.Groups[1].Value;
                    var number = int.Parse(match.Groups[2].Value);

                    if (!result.ContainsKey(prefix) || result[prefix] < number)
                    {
                        result[prefix] = number;
                    }
                }
            }

            return result;
        }

        public string GetId(AdministrativeUnitType type)
        {
            var latestIds = GetLatestIDsByPrefix();
            string prefix = type switch
            {
                AdministrativeUnitType.ThanhPho or AdministrativeUnitType.ThanhPhoTrungUong or AdministrativeUnitType.Tinh => "tinh",
                AdministrativeUnitType.Quan or AdministrativeUnitType.Huyen or AdministrativeUnitType.ThiXa => "huyen",
                AdministrativeUnitType.Xa or AdministrativeUnitType.Phuong or AdministrativeUnitType.ThiTran => "xa",
                _ => throw new ArgumentException("Unknown type")
            };

            int nextNumber = latestIds.ContainsKey(prefix) ? latestIds[prefix] + 1 : 1;
            return $"{prefix}{nextNumber}";
        }
    }
}
