using System;

public class AdministrativeUnit
{
    public AdministrativeUnit()
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<AdministrativeUnit> Children { get; set; }
}

}
