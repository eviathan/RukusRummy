using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.DataAccess.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }

        public bool IsSpectator { get; set; }

        // public dynamic Connection { get; set; }

        public List<Guid> Games { get; set; }
        
        public List<Guid> Decks { get; set;  }
    }
}