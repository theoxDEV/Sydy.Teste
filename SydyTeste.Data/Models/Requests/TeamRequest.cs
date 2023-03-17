using System.Text.Json.Serialization;

namespace SydyTeste.Data.Models.Requests
{
    public class TeamRequest
    {
        [JsonPropertyName("nome")]
        public required string Name { get; set; }
    }
}
