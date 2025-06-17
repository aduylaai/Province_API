using System.Text.Json.Serialization;

namespace Province_API.Infrastructure.Models
{
    public class LocationLevels
    {
        public class LocationRoot
        {
            [JsonPropertyName("data")]
            public List<LocationNode> Data { get; set; } = new();
        }

        public class LocationNode
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = string.Empty;
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;
            [JsonPropertyName("children")]
            public List<LocationNode>? Children { get; set; } = new();

        }
    }
}
