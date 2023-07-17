using Microsoft.AspNetCore.SignalR;

namespace RukusRummy.Api.Hubs
{
    public class SessionHub : Hub
    {
        public async Task PickCard(Guid userId, string card) 
        {
            await Clients.All.SendAsync("pickCard", card);
        }        
    }
}