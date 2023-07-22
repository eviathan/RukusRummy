using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.BusinessLogic.Repositories
{
    public class DeckMemoryRepository : IRepository<Deck>
    {
        private List<Deck> _decks { get; set; }

        public DeckMemoryRepository()
        {
            _decks = new List<Deck>
            {
                new Deck
                {
                    Id = Guid.Empty,
                    Name = "Fibonacci",
                    Values = "1, 2, 3, 5, 8, 13, 21, 34, 55, ?, \u2615\uFE0F"
                }
            };     
        }

        public async Task<Guid> CreateAsync(Deck entity)
        {
            _decks.Add(entity);
            return await Task.FromResult<Guid>(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var deck = _decks.FirstOrDefault(deck => deck.Id == id);

            if(deck == null)
                throw new ArgumentOutOfRangeException($"Could not find deck with id: {id}");

            _decks.Remove(deck);            
            await Task.Delay(10);
        }

        public async Task<Deck> GetAsync(Guid id)
        {
            var deck = _decks.FirstOrDefault(deck => deck.Id == id);

            if(deck == null)
                throw new ArgumentOutOfRangeException($"Could not find deck with id: {id}");

            return await Task.FromResult(deck);
        }

        public async Task<IEnumerable<Deck>> GetAllAsync()
        {
            return await Task.FromResult(_decks);
        }

        public async Task UpdateAsync(Deck entity)
        {
            var index = _decks.IndexOf(entity);

            if(index == -1)
                throw new ArgumentOutOfRangeException($"Could not find deck");

            _decks[index] = entity;
            await Task.Delay(10);
        }
    }
}