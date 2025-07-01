using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Repositories;
using static Province_API.Core.Domain.AdministrativeAggregate.Enums;

namespace Province_API.Core.Domain.AdministrativeAggregate
{
    public class AdministrativeUnitBuilder
    {
        //public string name;
        //public AdministrativeUnitType type;
        //public string? parentid;

        //public AdministrativeUnitBuilder SetName(string name)
        //{
        //    this.name = name;
        //    return this;
        //}

        //public AdministrativeUnitBuilder SetType(AdministrativeUnitType type)
        //{
        //    this.type = type;
        //    return this;
        //}

        //public AdministrativeUnitBuilder SetParentID(string parentId)
        //{
        //    this.parentid = parentId;
        //    return this;
        //}

        //public AdminstrativeUnit Build()
        //{
        //    var finalName = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;

        //    if (!Enum.TryParse(type.ToString(), out AdministrativeUnitType finalType))
        //    {
        //        finalType = AdministrativeUnitType.Xa; 
        //    }

        //    return new AdminstrativeUnit(finalName, finalType, this.parentid);
        //}

        private AdminstrativeUnit unit;


        public AdministrativeUnitBuilder()
        {
            this.unit = new AdminstrativeUnit();
        }

        public AdministrativeUnitBuilder SetID(string id)
        {
            unit.UpdateID(id);
            return this;
        }
        public AdministrativeUnitBuilder withID(string id)
        {
            unit.UpdateID(id);
            return this;
        }

        public AdministrativeUnitBuilder withName(string name)
        {
            unit.UpdateName(name);
            return this;
        }

        public AdministrativeUnitBuilder withParentId(string? parentId)
        {
            unit.UpdateParentId(parentId);
            return this;
        }

        public AdministrativeUnitBuilder withType(AdministrativeUnitType type)
        {
            unit.UpdateType(type);
            return this;
        }

        public void Reset() {
            this.unit = new AdminstrativeUnit();
        }
        public AdminstrativeUnit Build()
        {
            //Add logic here?

        
            

            var result = unit;
            this.Reset();
            return result;
        }

    }
}
