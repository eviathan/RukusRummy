using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class DeckService
    {
        private readonly IRepository<Deck> _deckRepository;

        public DeckService(IRepository<Deck> deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public async Task<Guid> CreateDeck()
        {
            throw new NotImplementedException();
        }

        public async Task<DeckDTO> GetDeck(Guid id)
        {
            var deck = await _deckRepository.GetAsync(id);
            return MapToDTO(deck);
        }

        public async Task<IEnumerable<DeckDTO>> GetDecks()
        {
            var decks = await _deckRepository.GetAllAsync();
            return await Task.FromResult(decks.Select(MapToDTO));
        }

        private DeckDTO MapToDTO(Deck deck)
        {
            return new DeckDTO
            {
                Id = deck.Id,
                Name = deck.Name,
                Values = deck.Values
            };
        }
    }
}