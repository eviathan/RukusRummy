using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class CreatePlayerRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public bool IsSpectator { get; set; }
    }
}