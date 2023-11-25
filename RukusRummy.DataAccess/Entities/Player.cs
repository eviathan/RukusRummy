using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class Player : Entity
{
    public string Name { get; set; }
    public bool IsSpectator { get; set; }
    public ICollection<Deck> Decks { get; set;  } = new List<Deck>();
    public ICollection<Game> Games { get; set; } = new List<Game>();

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasKey(player => player.Id);
    }
}