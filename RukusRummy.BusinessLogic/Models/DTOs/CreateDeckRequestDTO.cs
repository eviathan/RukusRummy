using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class CreateDeckRequestDTO
    {
        public string Name { get; set; }

        public string Values { get; set; }
    }
}