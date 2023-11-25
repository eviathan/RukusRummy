using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class Round : Entity
{
    public string Name { get; set; }
    public string Result { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<Vote> Votes{ get; set; }

    public Guid GameId { get; set; }
    public Game Game { get; set; }

    public int VoteCount => Votes
        ?.Where(vote => vote.Value != null)
        ?.Count() ?? 0;

    public string Average => "TODO";

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Round>()
            .HasKey(round => round.Id);

        modelBuilder.Entity<Round>()
            .HasMany(x => x.Votes)
            .WithOne(x => x.Round)
            .HasForeignKey(x => x.RoundId);
    }
}