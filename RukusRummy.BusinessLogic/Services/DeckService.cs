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

        public async Task<Guid> CreateAsync(string name, string values)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(values))
                throw new ArgumentNullException();

            var sanitisedValues = SanitisedValues(values);
            var dto = new DeckDTO(name, sanitisedValues);
            return await _deckRepository.CreateAsync(MapFromDTO(dto));
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
            return new DeckDTO
            {
                Id = deck.Id,
                Name = deck.Name,
                Values = deck.Values
            };
        }
    }
}