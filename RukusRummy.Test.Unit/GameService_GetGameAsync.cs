using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Models.DTOs;
using RukusRummy.BusinessLogic.Repositories;
using RukusRummy.BusinessLogic.Services;
using Moq;

namespace RukusRummy.Test.Unit
{
    public class GameService_GetGameAsync
    {
        private readonly GameService _gameService;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Deck> _deckRepository;

        public GameService_GetGameAsync()
        {
            _gameRepository = new GameMemoryRepository();
            _deckRepository = new DeckMemoryRepository();
            _gameService = new GameService(_gameRepository, _deckRepository);
        }

        [Fact]
        public async Task GivenAValidGameId_WhenGetGameAsyncIsInvoked_ValidGameIsReturned()
        {
            // Arrange
            var name = "Some Name";
            var autoReveal = true;
            var enableFunFeatures = true;

            var id = await _gameService.CreateAsync(new CreateGameDTO
            {
                Name = name,
                AutoReveal = autoReveal,
                EnableFunFeatures = enableFunFeatures,
                ManageIssuesPermission = PlayerPermissionType.JustMe,
                RevealCardsPermission = PlayerPermissionType.JustMe
            });

            // Act
            var game = await _gameService.GetAsync(id);

            // Assert
            Assert.NotNull(game);
            Assert.Equal(game.Id, id);
            Assert.Equal(game.Name, name);
            Assert.Equal(game.AutoReveal, autoReveal);
            Assert.Equal(game.EnableFunFeatures, enableFunFeatures);
            Assert.Equal(game.ManageIssuesPermission, PlayerPermissionType.JustMe);
            Assert.Equal(game.RevealCardsPermission, PlayerPermissionType.JustMe);
        }

        [Fact]
        public async Task GivenAnInvalidGameId_WhenGetGameAsyncIsInvoked_ArgumentOutOfRangeExceptionThrown()
        {
            // Act
            var act = () => _gameService.GetAsync(Guid.Empty);

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(act);
        }
    }
}