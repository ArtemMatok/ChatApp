using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChat.Shared.DTOs;

namespace TestChat.Shared.Chat
{
    public interface IBlazingChatHubClient
    {
        Task UserConnected(UserDto user);
        Task OnlineUsersList(IEnumerable<UserDto> users);
        Task UserIsOnline(int userId);
        Task MessageReceived(MessageDto messageDto);
    }
}
