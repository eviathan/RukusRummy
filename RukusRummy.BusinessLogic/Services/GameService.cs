using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.DataAccess.Entities;
using RukusRummy.DataAccess.Repositories;

namespace RukusRummy.BusinessLogic.Services
{
    public class GameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Deck> _deckRepository;
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Round> _roundRepository;

        public GameService(
            IRepository<Game> gameRepository, 
            IRepository<Deck> deckRepository,
            IRepository<Player> playerRepository,
            IRepository<Round> roundRepository)
        {
            _gameRepository = gameRepository;
            _deckRepository = deckRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
        }

        // TODO: Finish game creation logic
        public async Task<Game> CreateAsync(CreateGameDTO model)
        {
            var initalRound = new Round
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now
            };

            await _roundRepository.CreateAsync(initalRound);

            var player = await _playerRepository.GetAsync(model.PlayerId);

            var game = new Game 
            {
                Name = model.Name,
                Deck = model.Deck,
                Rounds = [ initalRound ],
                Players = [ player ],
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
            throw new NotImplementedException("This needs reimplementing");

            // var game = await _gameRepository.GetAsync(dto.GameId);
            // var latestRound = game.Rounds.LastOrDefault();

            // if(latestRound != null)
            // {
            //     latestRound.Votes.FirstOrDefault(x => x.Player.Id == dto.PlayerId).Value;
            //     await _roundRepository.UpdateAsync(latestRound);

            //     await _gameRepository.UpdateAsync(game);
            // }
        }

        public async Task StartNewRoundAsync(Guid gameId)
        {
            throw new NotImplementedException("This needs reimplementing");
            // var game = await _gameRepository.GetAsync(gameId);

            // var previousRound = await _roundRepository.GetAsync(game.Rounds.Last());
            // previousRound.EndDate = DateTime.Now;
            // await _roundRepository.UpdateAsync(previousRound);

            // var roundId = await _roundRepository.CreateAsync(new Round
            //     {
            //         Id = Guid.NewGuid(),
            //         StartDate = DateTime.Now
            //     }
            // );
            // game.Rounds.Add(roundId);

            // await _gameRepository.UpdateAsync(game);
        }

        private Game MapFromDTO(GameDTO dto)
        {
            return new Game
            {
                Id = dto.Id,
                Name = dto.Name,
                Deck = dto.Deck.Id,
                AutoReveal = dto.AutoReveal,
                EnableFunFeatures = dto.EnableFunFeatures,
                ManageIssuesPermission = dto.ManageIssuesPermission,
                Players = dto.Players.ToList(),
                RevealCardsPermission = dto.RevealCardsPermission,
                Rounds = dto.Rounds.ToList()
            };
        }

        private async Task<GameDTO> MapToDTO(Game game)
        {
            var deck = await _deckRepository.GetAsync(game.Deck);
            
            return new GameDTO
            {
                Id = game.Id,
                Name = game.Name,
                Deck = deck,
                AutoReveal = game.AutoReveal,
                EnableFunFeatures = game.EnableFunFeatures,
                ManageIssuesPermission = game.ManageIssuesPermission,
                Players = game.Players.ToList(),
                RevealCardsPermission = game.RevealCardsPermission,
                Rounds = game.Rounds.ToList()
            };
        }
    }
}