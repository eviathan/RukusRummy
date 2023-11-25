using Microsoft.EntityFrameworkCore;
using RukusRummy.DataAccess;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public class DeckRepository : IRepository<Deck>
    {
        private readonly RukusRummyDbContext _context;

        public DeckRepository(RukusRummyDbContext context)
        {
            _context = context;
        }

        public async Task<Deck> CreateAsync(Deck entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Deck> GetAsync(Guid id)
        {
            return await _context.Decks.SingleAsync(deck => deck.Id == id);
        }

        public async Task<IEnumerable<Deck>> GetAllAsync()
        {
            return await _context.Decks.ToListAsync();
        }

        public async Task UpdateAsync(Deck entity)
        {
            _context.Decks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var deck = new Deck { Id = id };
            _context.Decks.Attach(deck);
            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();
        }
    }
}