using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Domain.AdministrativeAggregate
{
    public class AdminstrativeUnit
    {
        public string Id { get; protected set; }

        public string Name { get; protected set; }

        public string? ParentId { get; protected set; }
        public AdministrativeUnitType Type { get; protected set; }

        public List<AdminstrativeUnit> Children { get; protected set; } = new List<AdminstrativeUnit>();

        public bool UpdateID(string id) { 
            bool isChange = false;
            if (id != null) { 
                this.Id = id;
            }
            return isChange;
        }
        public bool UpdateAdministrativeUnit(string name, AdministrativeUnitType type, string parentId)
        {
            bool isChange = false;

            if (name != Name)
            {
                Name = name;
                isChange = true;
            }

            if (type != Type)
            {
                Type = type;
                isChange = true;
            }

            if (parentId != ParentId)
            {
                ParentId = parentId;
                isChange = true;
            }

            return isChange;
        }
        internal AdminstrativeUnit(string name, AdministrativeUnitType type, string? parentId = null)
        {
            Name = name;
            Type = type;
            ParentId = parentId;
            Children = new List<AdminstrativeUnit>();
        }
        internal AdminstrativeUnit()
        {

        }

    }
}
