using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class AddPlayerDTO
    {
        public Guid GameId { get; set; }
        
        public string Name { get; set; }

        public bool IsSpectator { get; set; }
    }
}