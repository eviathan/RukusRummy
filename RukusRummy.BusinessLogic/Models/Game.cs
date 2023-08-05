using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models
{
    public class Game : Entity
    {
        public string Name { get; set; }

        public Guid Deck { get; set; }

        public List<Guid> Players { get; set; }

        public List<Guid> Rounds { get; set; }

        public bool AutoReveal { get; set; }
        
        public bool EnableFunFeatures { get; set; }
        
        public PlayerPermissionType ManageIssuesPermission { get; set; }

        public PlayerPermissionType RevealCardsPermission { get; set; }
    }
}