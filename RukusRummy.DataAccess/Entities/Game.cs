using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities
{
    public class Game : Entity
    {
        public string? Name { get; set; }
        public GameStateType State { get; set; }
        public Deck Deck { get; set; }
        public bool AutoReveal { get; set; }
        public bool EnableFunFeatures { get; set; }
        public bool ShowAverage { get; set; }
        public bool AutoCloseSession { get; set; }
        public PlayerPermissionType ManageIssuesPermission { get; set; }
        public PlayerPermissionType RevealCardsPermission { get; set; }

        public List<Player> Players { get; set; } = new ();
        public List<Round> Rounds { get; set; } = new ();

        internal static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasKey(game => game.Id);

            modelBuilder.Entity<Game>()
                .HasMany(game => game.Rounds)
                .WithOne(round => round.Game);
                
            modelBuilder.Entity<Game>()
                .HasMany(x => x.Players)
                .WithMany(x => x.Games)
                .UsingEntity(x => x.ToTable("GamePlayers"));
        }
    }
}