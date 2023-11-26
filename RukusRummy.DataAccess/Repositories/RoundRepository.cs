using Microsoft.EntityFrameworkCore;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public class RoundRepository : IRepository<Round>
    {
        private readonly RukusRummyDbContext _context;

        public RoundRepository(RukusRummyDbContext context)
        {
            _context = context;
        }

        public async Task<Round> CreateAsync(Round entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Round> GetAsync(Guid id)
        {
            return await _context.Rounds.SingleAsync(round => round.Id == id);
        }

        public async Task<List<Round>> GetRangeAsync(params Guid[] ids)
        {
            return await _context.Rounds
                .Where(round => ids.Contains(round.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Round>> GetAllAsync()
        {
            return await _context.Rounds.ToListAsync();
        }

        public async Task UpdateAsync(Round entity)
        {
            _context.Rounds.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var round = new Round { Id = id };
            _context.Rounds.Attach(round);
            _context.Rounds.Remove(round);
            await _context.SaveChangesAsync();
        }
    }
}