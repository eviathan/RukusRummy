using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class Player : Entity
{
    public string Name { get; set; }
    public bool IsSpectator { get; set; }
    
    public ICollection<Game> Games { get; set; } = new List<Game>();
    public ICollection<Deck> Decks { get; set; } = new List<Deck>();

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasKey(player => player.Id);
    }
}