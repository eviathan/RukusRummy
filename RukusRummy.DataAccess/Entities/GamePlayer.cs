
using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class GamePlayer : Entity
{
    public Guid GameId { get; set; }
    public Guid PlayerId { get; set; }

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GamePlayer>()
            .HasKey(gamePlayer => new 
                { 
                    gamePlayer.Id,
                    gamePlayer.GameId,
                    gamePlayer.PlayerId 
                }
            );  
            
        modelBuilder.Entity<Game>()
            .HasMany(game => game.Players)
            .WithMany(player => player.Games)
            .UsingEntity<GamePlayer>();
    }
}