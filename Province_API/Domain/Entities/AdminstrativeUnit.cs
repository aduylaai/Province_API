namespace Province_API.Domain.Entities
{
    public class AdminstrativeUnit
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? ParentId { get; set; }

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
