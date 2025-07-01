using Province_API.Core.Domain.AdministrativeAggregate;
using Province_API.Infrastructure.Models;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Infrastructure.Utils
{
    public class FlatAdministrativeUnit
    {
        private static void FlattenNode(LocationLevels.LocationNode node, string? parentID, List<AdminstrativeUnit> list)
        {
            var unitBuilder = new AdministrativeUnitBuilder();
            unitBuilder
                .SetParentID(parentID)
                .SetName(node.Name)
                .SetType(ConvertType(node.Type));
            AdminstrativeUnit unit= unitBuilder.Build();

            unit.UpdateID(node.Id);

            list.Add(unit);
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    FlattenNode(child, node.Id, list);
                }
            }
        }

        public static List<AdminstrativeUnit> FlattenAdministrativeUnit(List<LocationLevels.LocationNode> levels)
        {
            var result = new List<AdminstrativeUnit>();
            foreach (var level in levels)
            {
                FlattenNode(level, null, result);
            }
            return result;
        }

        public static AdministrativeUnitType ConvertType(string typeStr)
        {
            Enum.TryParse<AdministrativeUnitType>(typeStr, out var result);
            return result;
        }
    }
}
