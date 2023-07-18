using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models
{
    public class Game : Entity
    {
        public string Name { get; set; }

        public Deck Deck { get; set; }

        public List<Player> Players { get; set; }

        public List<Round> Rounds { get; set; }
    }
}