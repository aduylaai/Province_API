using System.Text.Json.Serialization;

namespace Province_API.Infrastructure.Models
{
    public class LocationLevels
    {
        public class LocationRoot
        {
            [JsonPropertyName("data")]
            public List<Level1> Data { get; set; } = new();
        }
        public class Level1
        {
            [JsonPropertyName("level1_id")]
            public string Level1Id { get; set; } = string.Empty;
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;
            [JsonPropertyName("level2s")]
            public List<Level2> Level2s { get; set; } = new();
        }
        public class Level2
        {
            [JsonPropertyName("level2_id")]
            public string Level2Id { get; set; } = string.Empty;
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;
            [JsonPropertyName("level3s")]
            public List<Level3> Level3s { get; set; } = new();
        }
        public class Level3
        {
            [JsonPropertyName("level3_id")]
            public string Level3Id { get; set; } = string.Empty;
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;
        }
    }
}
