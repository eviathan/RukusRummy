using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class CreateGameRequestDTO
    {
        public string? Name { get; set; }
        public Guid PlayerId { get; set; }
        public Guid DeckId { get; set; }
        public bool AutoReveal { get; set; }
        public bool EnableFunFeatures { get; set; }
        public bool ShowAverage { get; set; }
        public bool AutoCloseSession { get; set; }
        public PlayerPermissionType RevealCardsPermission { get; set; }
        public PlayerPermissionType ManageIssuesPermission { get; set; }
    }
}