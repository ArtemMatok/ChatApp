using Microsoft.AspNetCore.SignalR;
using TestChat.Shared.Chat;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Hubs
{
    
    public class BlazingChatHub : Hub<IBlazingChatHubClient>, IBlazingChatHubServer
    {
        //private static readonly ICollection<string> _connectedUsers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly IDictionary<int, UserDto> _connectedUsers = new Dictionary<int, UserDto>();
        public BlazingChatHub()
        {
            
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }


       

        public async Task ConnectUser(UserDto user)
        {
            await Clients.Caller.ConnectedUsersList(_connectedUsers.Values);

            if (!_connectedUsers.ContainsKey(user.Id))
            {
                _connectedUsers.Add(user.Id,user);
                await Clients.Others.UserConnected(user);
            }
        }
    }
}
