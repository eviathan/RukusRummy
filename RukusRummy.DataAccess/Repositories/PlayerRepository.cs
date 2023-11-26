using Microsoft.EntityFrameworkCore;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly RukusRummyDbContext _context;

        public PlayerRepository(RukusRummyDbContext context)
        {
            _context = context;   
        }

        public async Task<Player> CreateAsync(Player entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await _context.Players
                .Include(x => x.Decks)
                .SingleAsync(player => player.Id == id);
        }

        public async Task<List<Player>> GetRangeAsync(params Guid[] ids)
        {
            return await _context.Players
                .Where(player => ids.Contains(player.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task UpdateAsync(Player entity)
        {
            _context.Players.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var player = new Player { Id = id };
            _context.Players.Attach(player);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}