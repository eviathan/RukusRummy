using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic
{
    public class Round
    {
        public string Name { get; set; }

        public string Result { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Dictionary<Guid, int?> Votes { get; set; }

        public int VoteCount => Votes
            .Where(vote => vote.Value != null)
            .Count();
    }
}