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

        public PlayerService(IRepository<Player> playerRepository, IRepository<Game> gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }


        public async Task<Player> AddPlayerToGameAsync(AddPlayerDTO dto)
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
            var player = await _playerRepository.CreateAsync(new Player
            {
                Name = name,
                IsSpectator = isSpectator,
                // Decks = Defaults.DefaultDecks // TODO: Fix this by seeding and reattaching default deck 
            });

            return new(player);
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