using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RukusRummy.Api.Hubs
{
    public class GameHub : Hub
    {
        public async Task UpdateCard(Guid userId, string card) 
        {
            await Clients.All.SendAsync($"{nameof(GameHub)}.{nameof(UpdateCard)}", card);
        }

        public async Task RevealCards()
        {
            await Clients.All.SendAsync($"{nameof(GameHub)}.{nameof(RevealCards)}");
        }
    }
}