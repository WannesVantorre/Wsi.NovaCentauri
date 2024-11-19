using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsi.NovaCentauri.Cons.Models
{
    public class Game
    {
        public required List<Fighter> TeamA { get; set; }
        public required List<Fighter> TeamB { get; set; }
    }
}
