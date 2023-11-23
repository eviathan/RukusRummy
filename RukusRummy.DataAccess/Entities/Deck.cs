using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.DataAccess.Entities
{
    public class Deck : Entity
    {
        public string Name { get; set; }

        public string Values { get; set; }

        public string BackDesignImageUrl { get; set; }
    }
}