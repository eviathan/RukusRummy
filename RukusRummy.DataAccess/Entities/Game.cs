using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities
{
    public class Game : Entity
    {
        public string? Name { get; set; }

        public GameStateType State { get; set; }

        public Guid Deck { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public ICollection<Round> Rounds { get; set; } = new List<Round>();

        public bool AutoReveal { get; set; }
        
        public bool EnableFunFeatures { get; set; }

        public bool ShowAverage { get; set; }
        
        public bool AutoCloseSession { get; set; }
        
        public PlayerPermissionType ManageIssuesPermission { get; set; }

        public PlayerPermissionType RevealCardsPermission { get; set; }

        internal static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasKey(game => game.Id);

            modelBuilder.Entity<Game>()
                .HasMany(game => game.Rounds)
                .WithOne(round => round.Game)
                .HasForeignKey(round => round.GameId);
                
        }
    }
}