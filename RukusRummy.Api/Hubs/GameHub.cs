using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //     Clients.Others.SendAsync("UserConnected", Context.ConnectionId);
        //     return base.OnConnectedAsync();
        // }

        // public override Task OnDisconnectedAsync(Exception exception)
        // {
        //     Clients.Others.SendAsync("UserDisconnected", Context.ConnectionId);
        //     return base.OnDisconnectedAsync(exception);
        // }
        

        public async Task UpdateCard(string gameId, string playerId, int? card) 
        {
            await _gameService.PickCardAsync(new BusinessLogic.Models.DTOs.PickCardDTO {
                GameId = new Guid(gameId),
                PlayerId = new Guid(playerId),
                Value = card
            });

            await Clients.All.SendAsync($"GameUpdated", gameId);
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

        public async Task RevealCards()
        {
            await Clients.All.SendAsync($"{nameof(RevealCards)}");
        }
    }
}