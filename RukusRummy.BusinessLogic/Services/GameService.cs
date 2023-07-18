using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class GameService
    {
        private readonly IRepository<Game> _gameRepository;

        public GameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // TODO: Finish game creation logic
        public async Task<Guid> CreateGameAsync(CreateGameDTO model)
        {
            var game = new Game 
            {
                Name = model.Name,
            };
            
            return await _gameRepository.CreateAsync(game);            
        }

        public async Task<Game> GetGameAsync(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public async Task PickCardAsync(PickCardDTO model)
        {
            var game = await _gameRepository.GetAsync(model.GameId);
            var votes = game?.Rounds[model.Round]?.Votes;

            if(game == null || votes == null)
                throw new ArgumentOutOfRangeException("Coud not find game");
            
            votes[model.PlayerId] = model.Value;
            await _gameRepository.UpdateAsync(game);
        }

        public async Task RevealCardsAsync(Guid gameId)
        {
            var game = await _gameRepository.GetAsync(gameId);

            foreach (var player in game.Players)
            {
                // player.Notify(GameNotificationType.UpdateCards);   
            }
            await Task.Delay(12);
        }
    }
}