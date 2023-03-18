using System.Text.Json.Serialization;

namespace ConsoleApp1.Model
{
    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}