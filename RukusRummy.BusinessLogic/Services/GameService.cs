using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class GameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Deck> _deckRepository;
        private readonly IRepository<Player> _playerRepository;

        public GameService(
            IRepository<Game> gameRepository, 
            IRepository<Deck> deckRepository,
            IRepository<Player> playerRepository)
        {
            _gameRepository = gameRepository;
            _deckRepository = deckRepository;
            _playerRepository = playerRepository;
        }

        // TODO: Finish game creation logic
        public async Task<Guid> CreateAsync(CreateGameDTO model)
        {
            var game = new Game 
            {
                Name = model.Name,
                Deck = model.Deck,
                Rounds = new List<Guid>
                { 
                    // Guid.Empty
                },
                Players = new List<Guid>
                {  
                    // TODO: Add logged in user if exists
                },
                AutoReveal = model.AutoReveal,
                EnableFunFeatures = model.EnableFunFeatures,
                ManageIssuesPermission = model.ManageIssuesPermission,
                RevealCardsPermission = model.RevealCardsPermission
            };
            
            return await _gameRepository.CreateAsync(game);            
        }

        public async Task<GameDTO> GetAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(id);
            return await MapToDTO(game);
        }

        public async Task<IEnumerable<GameDTO>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            var dto = await Task.WhenAll(games.Select(MapToDTO)); 
            return await Task.FromResult(dto);
        }

        public async Task UpdateAsync(GameDTO dto)
        {
            var game = MapFromDTO(dto);
            await _gameRepository.UpdateAsync(game);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public async Task PickCardAsync(PickCardDTO dto)
        {
            var game = await _gameRepository.GetAsync(dto.GameId);
            // var votes = game?.Rounds[model.Round]?.Votes;

            // if(game == null || votes == null)
            //     throw new ArgumentOutOfRangeException("Coud not find game");
            
            // votes[model.PlayerId] = model.Value;
            await _gameRepository.UpdateAsync(game);
        }

        private Game MapFromDTO(GameDTO dto)
        {
            return new Game
            {
                Id = dto.Id,
                Name = dto.Name,
                Deck = dto.Deck,
                AutoReveal = dto.AutoReveal,
                EnableFunFeatures = dto.EnableFunFeatures,
                ManageIssuesPermission = dto.ManageIssuesPermission,
                Players = dto.Players.Select(x => x.Id).ToList(),
                RevealCardsPermission = dto.RevealCardsPermission,
                Rounds = dto.Rounds.Select(x => x.Id).ToList()
            };
        }

        private async Task<GameDTO> MapToDTO(Game game)
        {
            var players = await Task.WhenAll(
                game.Players.Select(async x => 
                    await _playerRepository.GetAsync(x)
                )
            );

            var rounds = await Task.WhenAll(
                game.Rounds.Select(async x => 
                    await _playerRepository.GetAsync(x)
                )
            );
            
            return new GameDTO
            {
                Id = game.Id,
                Name = game.Name,
                Deck = game.Deck,
                AutoReveal = game.AutoReveal,
                EnableFunFeatures = game.EnableFunFeatures,
                ManageIssuesPermission = game.ManageIssuesPermission,
                Players = players.ToList(),
                RevealCardsPermission = game.RevealCardsPermission,
                // Rounds = game.Rounds
            };
        }
    }
}