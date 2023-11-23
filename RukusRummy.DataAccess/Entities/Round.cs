using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.DataAccess.Entities
{
    public class Round : Entity
    {
        // NOTE: Named Rounds is a feature on planningpokeronline.com and could be useful
        public string Name { get; set; }

        public string Result { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Dictionary<Guid, int?> Votes { get; set; } = new Dictionary<Guid, int?>();

        public int VoteCount => Votes
            ?.Where(vote => vote.Value != null)
            ?.Count() ?? 0;

        public string Average => "TODO";
    }
}