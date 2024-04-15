using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Chat
{
    public interface IBlazingChatHubClient
    {
        void ReceiveMessage(string message);

    }
}
