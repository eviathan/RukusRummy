
using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class PlayerDeck : Entity
{
    public Guid PlayerId { get; set; }
    public Player Player { get; set; }

    public Guid DeckId { get; set; }
    public Deck Deck { get; set; }

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerDeck>()
            .HasKey(playerDeck => new 
                { 
                    playerDeck.Id,
                    playerDeck.PlayerId,
                    playerDeck.DeckId,
                }
            );
            
        modelBuilder.Entity<Player>()
            .HasMany(player => player.Decks)
            .WithMany(deck => deck.Players)
            .UsingEntity<PlayerDeck>();
    }
}