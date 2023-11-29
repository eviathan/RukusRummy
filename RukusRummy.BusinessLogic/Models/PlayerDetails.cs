using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models.DTOs;

namespace RukusRummy.BusinessLogic.Models
{
    public class PlayerDetails
    {
        public string Name { get; set; }
         public bool IsSpectator { get; set; }
        public List<DeckDTO> Decks { get; set; }
    }
}