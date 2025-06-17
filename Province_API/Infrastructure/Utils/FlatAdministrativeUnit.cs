using Province_API.Application.DTOs;
using Province_API.Domain.Entities;
using Province_API.Infrastructure.Models;

namespace Province_API.Infrastructure.Utils
{
    public class FlatAdministrativeUnit
    {
        private static void FlattenNode(LocationLevels.LocationNode node, string? parentID, List<AdminstrativeUnit> list)
        {
            list.Add(new AdminstrativeUnit
            {
                Id = node.Id,
                Name = node.Name,
                ParentId = parentID,
                Type = node.Type,
                Children = new List<AdminstrativeUnit>()
            });
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
    }
}
