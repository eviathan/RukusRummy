using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class DeckDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Values { get; set; }
    }
}