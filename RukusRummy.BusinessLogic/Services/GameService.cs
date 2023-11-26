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
        private readonly IRepository<Vote> _voteRepository;

        public GameService(
            IRepository<Game> gameRepository, 
            IRepository<Deck> deckRepository,
            IRepository<Player> playerRepository,
            IRepository<Round> roundRepository,
            IRepository<Vote> voteRepository)
        {
            _gameRepository = gameRepository;
            _deckRepository = deckRepository;
            _playerRepository = playerRepository;
            _roundRepository = roundRepository;
            _voteRepository = voteRepository;
        }

        // TODO: Finish game creation logic
        public async Task<GameDTO> CreateAsync(CreateGameRequestDTO model)
        {
            var player = await _playerRepository.GetAsync(model.PlayerId);
            var deck = await _deckRepository.GetAsync(model.DeckId);

            var game = new Game 
            {
                Name = model.Name,
                Deck = deck,
                Players = [ player ],
                AutoReveal = model.AutoReveal,
                EnableFunFeatures = model.EnableFunFeatures,
                ManageIssuesPermission = model.ManageIssuesPermission,
                RevealCardsPermission = model.RevealCardsPermission
            };

            var initialRound = new Round
            {
                Game = game,
            };

            game.Rounds.Add(initialRound);

            await _gameRepository.CreateAsync(game);

            return new GameDTO(game);
        }

        public async Task<GameDTO> GetAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(id);
            return new GameDTO(game);
        }

        public async Task<IEnumerable<GameDTO>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return games.Select(x => new GameDTO(x));
        }

        public async Task UpdateAsync(GameDTO dto)
        {
            var game = await _gameRepository.GetAsync(dto.Id);
            var deck = await _deckRepository.GetAsync(dto.Deck.Id);

            game.Name = dto.Name;
            game.State = dto.State;
            game.Deck = deck;
            game.AutoReveal = dto.AutoReveal;
            game.EnableFunFeatures = dto.EnableFunFeatures;
            game.ShowAverage = dto.ShowAverage;
            game.AutoCloseSession = dto.AutoCloseSession;
            game.ManageIssuesPermission = dto.ManageIssuesPermission;
            game.RevealCardsPermission = dto.RevealCardsPermission;

            await _gameRepository.UpdateAsync(game);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public async Task PickCardAsync(PickCardDTO dto)
        {
            var game = await _gameRepository.GetAsync(dto.GameId);
            var player = await _playerRepository.GetAsync(dto.PlayerId);
            var latestRound = game.Rounds.LastOrDefault();

            if(latestRound != null && latestRound.Votes != null)
            {
                var vote = latestRound.Votes.FirstOrDefault(x => x.Player.Id == dto.PlayerId);

                if(vote == null)
                {
                    await _voteRepository.CreateAsync(new Vote
                        {
                            Game = game,
                            Player = player,
                            Round = latestRound,
                            Value = dto.Value
                        }
                    );
                }
                else
                {
                    vote.Value = dto.Value;
                    await _voteRepository.UpdateAsync(vote);
                }
            }
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

        public async Task AddPlayerAsync(Guid gameId, Guid playerId)
        {
            var game = await _gameRepository.GetAsync(gameId);

            if(!game.Players.Any(x => x.Id == playerId))
            {
                var player = await _playerRepository.GetAsync(playerId);

                game.Players.Add(player);

                await _gameRepository.UpdateAsync(game);
            }
        }
    }
}