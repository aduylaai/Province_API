using Province_API.Core.Application.DTOs;
using Province_API.Core.Domain.Entities;
using Province_API.Infrastructure.Models;
using static Province_API.Core.Domain.Enums;

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
                Type = ConvertType(node.Type),
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

        public static AdministrativeUnitType ConvertType(string typeStr)
        {
            return typeStr switch
            {
                "Thành phố Trung ương" => AdministrativeUnitType.ThanhPhoTrungUong,
                "Tỉnh" => AdministrativeUnitType.Tinh,
                "Quận" => AdministrativeUnitType.Quan,
                "Huyện" => AdministrativeUnitType.Huyen,
                "Thành phố" => AdministrativeUnitType.ThanhPho,
                "Phường" => AdministrativeUnitType.Phuong,
                "Xã" => AdministrativeUnitType.Xa,
                "Thị trấn" => AdministrativeUnitType.ThiTran,
                "Thị xã" => AdministrativeUnitType.ThiXa,
                _ => throw new ArgumentException($"Unknown type {typeStr}")
            };
        }
    }
}
