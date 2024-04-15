using Microsoft.AspNetCore.SignalR;
using TestChat.Shared.Chat;

namespace TestChat.Server.Hubs
{
    
    public class BlazingChatHub : Hub<IBlazingChatHubClient>
    {
        public BlazingChatHub()
        {
            
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
