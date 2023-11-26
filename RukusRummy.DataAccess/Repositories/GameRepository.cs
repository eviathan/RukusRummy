using Microsoft.EntityFrameworkCore;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly RukusRummyDbContext _context;

        public GameRepository(RukusRummyDbContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateAsync(Game entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }      

        public async Task<Game> GetAsync(Guid id)
        {
            return await _context.Games
                .Include(x => x.Deck)
                .Include(x => x.Players)
                    .ThenInclude(x => x.Decks)
                .Include(x => x.Rounds)
                    .ThenInclude(x => x.Votes)
                .SingleAsync(game => game.Id == id);
        }

        public async Task<List<Game>> GetRangeAsync(params Guid[] ids)
        {
            return await _context.Games
                .Where(game => ids.Contains(game.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task UpdateAsync(Game entity)
        {
            _context.Games.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var game = new Game { Id = id };
            _context.Games.Attach(game);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}