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

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
            SELECT
                MAX(CAST(id AS BIGINT)) FILTER (WHERE length(id) = 2) AS max_level1,
                MAX(CAST(id AS BIGINT)) FILTER (WHERE length(id) = 3) AS max_level2,
                MAX(CAST(id AS BIGINT)) FILTER (WHERE length(id) = 5) AS max_level3
            FROM ""administrative_unit"";";

                this.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var level1 = reader.IsDBNull(0) ? "0" : reader.GetInt64(0).ToString();
                        var level2 = reader.IsDBNull(1) ? "0" : reader.GetInt64(1).ToString();
                        var level3 = reader.IsDBNull(2) ? "0" : reader.GetInt64(2).ToString();

                        result.Add(int.Parse(level1));
                        result.Add(int.Parse(level2));
                        result.Add(int.Parse(level3));
                    }
                }
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
