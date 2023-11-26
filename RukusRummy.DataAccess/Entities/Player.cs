using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class Player : Entity
{
    public string Name { get; set; }
    public bool IsSpectator { get; set; }
    
    public List<Game> Games { get; set; } = new ();
    public List<Deck> Decks { get; set; } = new ();

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasKey(player => player.Id);

        modelBuilder.Entity<Player>()
            .HasMany(x => x.Decks)
            .WithMany(x => x.Players)
            .UsingEntity(j => j.ToTable("PlayerDecks"));
    }
}