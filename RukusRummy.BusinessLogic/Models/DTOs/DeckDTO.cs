using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class DeckDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Values { get; set; }

        public DeckDTO(Deck deck)
        {
            Id = deck.Id;
            Name = deck.Name;
            Values = deck.Values;
        }
    }
}