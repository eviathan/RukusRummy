using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class GameDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Deck Deck { get; set; }

        public List<Player> Players { get; set; }

        public List<Round> Rounds { get; set; }

        public bool AutoReveal { get; set; }
        
        public bool EnableFunFeatures { get; set; }

        public bool ShowAverage { get; set; }
        
        public bool AutoCloseSession { get; set; }
        
        public PlayerPermissionType ManageIssuesPermission { get; set; }

        public PlayerPermissionType RevealCardsPermission { get; set; }
    }
}