using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess.Entities;
 
public class Deck : Entity
{
    public string Name { get; set; }
    public string Values { get; set; }

    // TODO: Custom back images
    // public string BackDesignImageUrl { get; set; }

    public Guid PlayerId { get; set; }
    public Player Player { get; set; }

    internal static void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deck>()
            .HasKey(deck => deck.Id);
    }
}