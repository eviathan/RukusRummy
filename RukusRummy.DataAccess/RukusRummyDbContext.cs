using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace RukusRummy.DataAccess
{
    public class RukusRummyDbContext : DbContext
    {
        public RukusRummyDbContext(DbContextOptions<RukusRummyDbContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "RukusRummy");
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}