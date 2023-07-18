using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class PickCardDTO
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }

        public int Round { get; set; }

        public int Value { get; set; }
    }
}