using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Domain.AdministrativeAggregate
{
    [Table("administrative_unit")]
    public class AdminstrativeUnit
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("parentId")]
        public string? ParentId { get; set; }
        [Column("type")]
        public AdministrativeUnitType Type { get; set; }

        public List<AdminstrativeUnit> Children { get; set; } = new List<AdminstrativeUnit>();


        public AdminstrativeUnit(string id, string name, AdministrativeUnitType type, string? parentId = null)
        {
            Id = id;
            Name = name;
            Type = type;
            ParentId = parentId;
        }
        public AdminstrativeUnit()
        {
            
        }
    }
}
