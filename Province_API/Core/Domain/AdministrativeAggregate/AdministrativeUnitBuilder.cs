using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Repositories;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Domain.AdministrativeAggregate
{
    public class AdministrativeUnitBuilder
    {
        public string name;
        public AdministrativeUnitType type;
        public string? parentid;

        public AdministrativeUnitBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public AdministrativeUnitBuilder SetType(AdministrativeUnitType type)
        {
            this.type = type;
            return this;
        }

        public AdministrativeUnitBuilder SetParentID(string parentId)
        {
            this.parentid = parentId;
            return this;
        }

        public AdminstrativeUnit Build()
        {
           return new AdminstrativeUnit(this.name, this.type, this.parentid);
        }
    }
}
