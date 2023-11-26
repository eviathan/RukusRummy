using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.DataAccess;
using RukusRummy.DataAccess.Entities;
using RukusRummy.DataAccess.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class PlayerService
    {
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Deck> _deckRepository;

        public PlayerService(
            IRepository<Player> playerRepository,
            IRepository<Game> gameRepository,
            IRepository<Deck> deckRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _deckRepository = deckRepository ?? throw new ArgumentNullException(nameof(deckRepository));
        }


        public async Task<PlayerDTO> AddPlayerToGameAsync(AddPlayerDTO dto)
        {
            throw new NotImplementedException();
            // var player = await _playerRepository.CreateAsync(new Player
            // {
            //     Name = dto.Name,
            //     IsSpectator = dto.IsSpectator,
            //     Decks = Defaults.DefaultDecks
            // });

            // var game = await _gameRepository.GetAsync(dto.GameId);
            // game.Players.Add(player);

            // await _gameRepository.UpdateAsync(game);

            // return player;
        }

        public async Task<PlayerDTO> CreateAsync(string name, bool isSpectator)
        {
            var defaultDeckIds = Defaults.DefaultDecks.Select(deck => deck.Id);
            var defaultDecks = await _deckRepository.GetRangeAsync(defaultDeckIds.ToArray());

            var player = await _playerRepository.CreateAsync(
                new Player
                {
                    Name = name,
                    IsSpectator = isSpectator,
                    Decks = defaultDecks
                }
            );

            return new PlayerDTO(player);
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            return players.Select(player => new PlayerDTO(player));
        }

        public async Task<PlayerDTO> GetPlayerAsync(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            return new PlayerDTO(player);
        }
    }
}