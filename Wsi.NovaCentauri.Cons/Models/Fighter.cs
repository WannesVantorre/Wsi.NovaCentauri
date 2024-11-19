using System.Text.Json.Serialization;

namespace Wsi.NovaCentauri.Cons.Models
{
    public class Fighter
    {
        [JsonPropertyName("strength")]
        public required int Strength { get; set; }
        [JsonPropertyName("speed")]
        public required int Speed { get; set; }
        [JsonPropertyName("health")]
        public required int Health { get; set; }
    }
}
