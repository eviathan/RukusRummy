using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}