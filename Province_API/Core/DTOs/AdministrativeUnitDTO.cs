namespace Province_API.Core.DTOs
{
    public class AdministrativeUnitDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string? ParentId { get; set; } = null;

        public AdministrativeUnitDTO(string id, string Name, string Type, string? ParentID)
        {
            this.Id = id;
            this.Name = Name;
            this.Type = Type;
            this.ParentId = ParentID;
        }
        public AdministrativeUnitDTO()
        {
                
        }
    }
}
