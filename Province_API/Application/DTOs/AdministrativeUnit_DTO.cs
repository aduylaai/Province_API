namespace Province_API.Application.DTOs
{
    public class AdministrativeUnit_DTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string? ParentId { get; set; } = null;
    }
}
