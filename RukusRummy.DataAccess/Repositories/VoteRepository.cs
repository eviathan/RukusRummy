using Microsoft.EntityFrameworkCore;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public class VoteRepository : IRepository<Vote>
    {
        private readonly RukusRummyDbContext _context;

        public VoteRepository(RukusRummyDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> CreateAsync(Vote entity)
    {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Vote> GetAsync(Guid id)
        {
            return await _context.Votes.SingleAsync(vote => vote.Id == id);
        }

        public async Task<List<Vote>> GetRangeAsync(params Guid[] ids)
        {
            return await _context.Votes
                .Where(vote => ids.Contains(vote.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Vote>> GetAllAsync()
        {
            return await _context.Votes.ToListAsync();
        }

        public async Task UpdateAsync(Vote entity)
        {
            _context.Votes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var vote = new Vote { Id = id };
            _context.Votes.Attach(vote);
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
        }
    }
}