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

        public List<Guid> Players { get; set; } = new List<Guid>();

        public List<Guid> Rounds { get; set; } = new List<Guid>();

        public bool AutoReveal { get; set; }
        
        public bool EnableFunFeatures { get; set; }

        public bool ShowAverage { get; set; }
        
        public bool AutoCloseSession { get; set; }
        
        public PlayerPermissionType ManageIssuesPermission { get; set; }

        public PlayerPermissionType RevealCardsPermission { get; set; }
    }
}