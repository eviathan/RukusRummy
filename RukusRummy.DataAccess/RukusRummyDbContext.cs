using RukusRummy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess;

public class RukusRummyDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<GamePlayer> GamePlayers { get; set; }
    public DbSet<Vote> Votes { get; set; }

    public RukusRummyDbContext(DbContextOptions<RukusRummyDbContext> options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Password123!");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Entities
        Game.BuildModel(modelBuilder);
        Deck.BuildModel(modelBuilder);
        Player.BuildModel(modelBuilder);
        Round.BuildModel(modelBuilder);
        Vote.BuildModel(modelBuilder);

        // Link Tables
        GamePlayer.BuildModel(modelBuilder);
    }
}