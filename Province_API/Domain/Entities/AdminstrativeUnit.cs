using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Province_API.Domain.Entities
{
    [Table("administrative_unit")]
    public class AdminstrativeUnit
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("parentid")]
        public string? ParentId { get; set; }
        [Column("type")]
        public string Type { get; set; }

        public List<AdminstrativeUnit> Children { get; set; } = new List<AdminstrativeUnit>();


        public AdminstrativeUnit(string id, string name, string type, string? parentId = null)
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
