using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class RoundDTO
    {
        public string? Name { get; set; }
        public string? Result { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public Dictionary<Guid, int?> Votes { get; set; } = new ();

        public RoundDTO(Round round)
        {
            Name = round.Name;
            Result = round.Result;
            StartDate = round.StartDate;
            EndDate = round.EndDate;
            Votes = round.Votes.ToDictionary(
                x => x.Player.Id,
                x => x.Value
            );
        }
    }
}