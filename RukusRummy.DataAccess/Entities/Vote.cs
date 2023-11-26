using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;

public class Vote : Entity
{
    public Player Player { get; set; }

    public Game Game { get; set; }

    public int Value { get; set; }

    public Guid RoundId { get; set; }
    public Round Round { get; set; }

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vote>()
            .HasKey(vote => vote.Id);
    }
}