using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RukusRummy.Api.Hubs
{
    public class GameHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Others.SendAsync("UserConnected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Others.SendAsync("UserDisconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task UpdateCard(Guid userId, int card) 
        {
            await Clients.All.SendAsync($"UserUpdatedCard", userId, card);
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