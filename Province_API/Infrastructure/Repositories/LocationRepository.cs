using Microsoft.EntityFrameworkCore;
using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Utils;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Infrastructure.Repositories
{
    public class LocationRepository : GenericRepository<AdminstrativeUnit>, ILocationRepository
    {
        private readonly AppDbContext _appDBContext;
        private readonly DbSet<AdminstrativeUnit> adminstrativeUnits;
        public LocationRepository(AppDbContext appDBContext) : base(appDBContext) {
            adminstrativeUnits = appDBContext.AdministrativeUnits;
        }
        //{
        //    _appDBContext = appDBContext;
        //    adminstrativeUnits = appDBContext.AdministrativeUnits;
        //}
        //public async Task<AdminstrativeUnit> AddAsync(AdminstrativeUnit entity)
        //{
        //    await _appDBContext.AddAsync(entity);
        //    return entity;
        //}

        //public async Task<List<AdminstrativeUnit>> GetAllAsync()
        //{
        //    var administrativeUnits = await adminstrativeUnits
        //        .ToListAsync();

        //    return administrativeUnits;
        //}


        //public async Task<AdminstrativeUnit> GetByIdAsync(string id)
        //{
        //    var result = await adminstrativeUnits.FirstOrDefaultAsync(u => u.Id == id);

        //    return result == null ? null : result;
        //}

        //public async Task<AdminstrativeUnit> UpdateLocationAsync(AdminstrativeUnit location)
        //{
        //    adminstrativeUnits.Update(location);

        //    return location;
        //}

        public async Task<QueryableWrapper<AdminstrativeUnit>> GetAllChildrenByIdAsync(string id)
        {

            var children = adminstrativeUnits
                .Where(x => x.ParentId == id);
            var childrenWrapper = new QueryableWrapper<AdminstrativeUnit>(children);

            return childrenWrapper;
        }

        public async Task<QueryableWrapper<AdminstrativeUnit>> GetAllProvinces()
        {
            var provinces = adminstrativeUnits
                .Where(u => u.ParentId == null);

            var queryProvinces = new QueryableWrapper<AdminstrativeUnit>(provinces);

            return queryProvinces;
        }

        public async Task<List<string>> GetID(string entityType)
        {
            var id = GetId(FlatAdministrativeUnit.ConvertType(entityType));
            return await Task.FromResult(new List<string> { id });
        }

        public async Task<bool> HasParentIsDeleted(string id)
        {
            var parent = await adminstrativeUnits
                            .FromSqlRaw(@"SELECT * FROM getancestors({0})", id)
                            .AsNoTracking()
                            .ToListAsync();

            return parent.Any(x => x.IsDelete);

        }

        public async Task RemoveAsync(AdminstrativeUnit entity)
        {
            _appDBContext.Remove(entity);
        }


        private Dictionary<string, int> GetLatestIDsByPrefix()
        {
            var result = new Dictionary<string, int>();

            var ids = adminstrativeUnits
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

        public async Task<bool> IsAvailableAsync(string id) {
            var unit = await GetByIdAsync(id);

            if (unit == null || unit.IsDelete || await HasParentIsDeleted(unit.Id))
            {
                return false;
            }
            return true;
        }

    }
}
