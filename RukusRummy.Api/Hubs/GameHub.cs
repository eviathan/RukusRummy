using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameService _gameService;

        public GameHub(GameService gameService)
        {
            _gameService = gameService;
        }

        // public override Task OnConnectedAsync()
        // {
        //     // Clients.Others.SendAsync("UserConnected", Context.ConnectionId);
        //     return base.OnConnectedAsync();
        // }

        // public override Task OnDisconnectedAsync(Exception exception)
        // {
        //     // var playerId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     // Clients.Others.SendAsync("UserDisconnected", Context.ConnectionId);
        //     return base.OnDisconnectedAsync(exception);
        // }

        public async Task JoinGame(Guid gameId)
        {
            try 
            {
                var _ = await _gameService.GetAsync(gameId);
                await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
            }
            catch(Exception ex)
            {
                await Clients.Caller.SendAsync("Error", ex.Message);
            }
        }

        public async Task UpdateCard(string gameId, string playerId, int? card) 
        {
            try
            {
                var gameIdGuid = new Guid(gameId);
                var _ = await _gameService.GetAsync(gameIdGuid);
                
                await _gameService.PickCardAsync(new BusinessLogic.Models.DTOs.PickCardDTO {
                    GameId = gameIdGuid,
                    PlayerId = new Guid(playerId),
                    Value = card
                });

                await Clients.Group(gameId).SendAsync($"GameUpdated", gameId);
            }
            catch(Exception ex)
            {
                await Clients.Caller.SendAsync("Error", ex.Message);
            }
        }

        public async Task ThrowTextAtUser(Guid userId, string text)
        {
            await Clients.All.SendAsync(
                $"{nameof(ThrowTextAtUser)}", 
                new 
                {
                    User = userId,
                    Text = text
                }
            );
        }

        public async Task RevealCards(Guid gameId)
        {
            try 
            {
                var _ = await _gameService.GetAsync(gameId);
                await Clients.Group(gameId.ToString()).SendAsync($"{nameof(RevealCards)}");
            }
            catch(Exception ex)
            {
                await Clients.Caller.SendAsync("Error", ex.Message);
            }
        }
    }
}