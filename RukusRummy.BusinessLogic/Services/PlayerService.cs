using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class PlayerService
    {
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Game> _gameRepository;

        public PlayerService(IRepository<Player> playerRepository, IRepository<Game> gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }


        public async Task<Guid> AddPlayerToGameAsync(AddPlayerDTO dto)
        {
            var playerId = await _playerRepository.CreateAsync(new Player
            {
                Name = dto.Name,
                IsSpectator = dto.IsSpectator,
                Decks = Defaults.DefaultDecks.Select(x => x.Id).ToList()
            });

            var game = await _gameRepository.GetAsync(dto.GameId);
            game.Players.Add(playerId);
            await _gameRepository.UpdateAsync(game);

            return playerId;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            return await _playerRepository.GetAsync(id);
        }
    }
}