using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSpectator { get; set; }
        public ICollection<DeckDTO> Decks { get; set;  }

        public PlayerDTO(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            IsSpectator = player.IsSpectator;
            Decks = player.Decks.Select(deck => new DeckDTO(deck)).ToList();
        }
    }
}