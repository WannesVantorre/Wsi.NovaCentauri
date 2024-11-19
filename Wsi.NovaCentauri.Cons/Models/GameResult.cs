using System.Text.Json.Serialization;

namespace Wsi.NovaCentauri.Cons.Models
{
    public class GameResult
    {
        [JsonPropertyName("winningTeam")]
        public required string WinningTeam { get; set; }
        [JsonPropertyName("remainingHealth")]
        public int RemainingHealth { get; set; }
    }
}
