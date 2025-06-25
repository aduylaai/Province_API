using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces;
using Province_API.Core.Domain.AdministrativeAggregate;
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
                entity.Property(e => e.Type)
                      .HasConversion<string>();
                entity.ToTable("administrative_unit");
            });
        }

        private List<int> GetLatestID()
        {
            List<int> result = new List<int>();
            int[] expectedLengths = { 2, 3, 5 };
            foreach (int lenght in expectedLengths) {
                var levelMax = AdministrativeUnits
                  .Where(x => x.Id.Length == lenght)
                  .Select(x => Convert.ToInt64(x.Id))
                  .DefaultIfEmpty(0)
                  .Max();
                result.Add((int)levelMax);
            }
            return result;
        }

        public string GetId(AdministrativeUnitType type)
        {
            string id = "0";

            List<int> latestId = GetLatestID();
            if (type == AdministrativeUnitType.ThanhPho || type == AdministrativeUnitType.ThanhPhoTrungUong || type == AdministrativeUnitType.Tinh)
            {
                id = (latestId[0] + 1).ToString();
            }
            else if (type == AdministrativeUnitType.Quan || type == AdministrativeUnitType.Huyen || type == AdministrativeUnitType.ThiXa)
            {
                id = (latestId[1] + 1).ToString();
            }
            else if (type == AdministrativeUnitType.Xa || type == AdministrativeUnitType.Phuong || type == AdministrativeUnitType.ThiTran)
            {
                id = (latestId[2] + 1).ToString();
            }
            return id;
        }
    }
}
