using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChat.Shared.DTOs;

namespace TestChat.Shared.Chat
{
    public interface IBlazingChatHubServer
    {
        Task ConnectUser(UserDto user);
    }
}
