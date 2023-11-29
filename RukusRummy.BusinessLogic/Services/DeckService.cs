using System.Diagnostics.CodeAnalysis;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.DataAccess.Entities;
using RukusRummy.DataAccess.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class DeckService
    {
        private readonly IRepository<Deck> _deckRepository;

        public DeckService(IRepository<Deck> deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public async Task<DeckDTO> CreateAsync(CreateDeckRequestDTO model)
        {
            var sanitisedValues = SanitisedValues(model.Values);
            var deck = await _deckRepository.CreateAsync(new Deck
            {
                Name = model.Name,
                Values = sanitisedValues
            });

            return new DeckDTO(deck);
        }

        public async Task<DeckDTO> GetAsync(Guid id)
        {
            var deck = await _deckRepository.GetAsync(id);
            return MapToDTO(deck);
        }

        public async Task<IEnumerable<DeckDTO>> GetAllAsync()
        {
            var decks = await _deckRepository.GetAllAsync();
            return decks.Select(MapToDTO);
        }

        public async Task UpdateAsync(DeckDTO dto)
        {
            var deck = MapFromDTO(dto);
            await _deckRepository.UpdateAsync(deck);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _deckRepository.DeleteAsync(id);
        }

        private string SanitisedValues(string values)
        {
            return string.Join(',', values.Split(',').Select(x => x.Replace(" ", string.Empty)));
        }

        private Deck MapFromDTO(DeckDTO dto)
        {
            return new Deck
            {
                Id = dto.Id,
                Name = dto.Name,
                Values = dto.Values
            };
        }

        private DeckDTO MapToDTO(Deck deck)
        {
            return new DeckDTO(deck);
        }
    }
}