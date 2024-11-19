using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wsi.NovaCentauri.Cons.Models
{
    public class Game
    {
        [JsonPropertyName("teamA")]
        public required List<Fighter> TeamA { get; set; }
        [JsonPropertyName("teamB")]
        public required List<Fighter> TeamB { get; set; }
    }
}
