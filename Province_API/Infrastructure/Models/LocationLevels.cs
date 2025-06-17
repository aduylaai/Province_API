namespace Province_API.Infrastructure.Models
{
    public class LocationLevels
    {
        public class LocationRoot
        {
            public List<Level1> Data { get; set; } = new();
        }
        public class Level1
        {
            public string Level1Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public List<Level2> Level2s { get; set; } = new();
        }
        public class Level2
        {
            public string Level2Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public List<Level3> Level3s { get; set; } = new();
        }
        public class Level3
        {
            public string Level3Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
        }
    }
}
