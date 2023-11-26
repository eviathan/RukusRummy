using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RukusRummy.DataAccess
{
    public class RukusRummyDbContextFactory : IDesignTimeDbContextFactory<RukusRummyDbContext>
    {
        public RukusRummyDbContext CreateDbContext(string[] args)
        {
            // TODO: Swap this out for SQL if need be
            var optionsBuilder = new DbContextOptionsBuilder<RukusRummyDbContext>();

            optionsBuilder
                .UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Password123!;Include Error Detail=true;");

            return new RukusRummyDbContext(optionsBuilder.Options);
        }
    }
}