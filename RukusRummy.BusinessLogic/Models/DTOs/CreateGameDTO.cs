using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class CreateGameDTO
    {
        public string? Name { get; set; }
        public Guid PlayerId { get; set; }
        public Guid Deck { get; set; }
        public bool AutoReveal { get; set; }
        public bool EnableFunFeatures { get; set; }
        public bool ShowAverage { get; set; }
        public bool AutoCloseSession { get; set; }
        public PlayerPermissionType RevealCardsPermission { get; set; }
        public PlayerPermissionType ManageIssuesPermission { get; set; }
    }
}