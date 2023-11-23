using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.DataAccess.Entities
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}