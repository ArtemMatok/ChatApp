using TestChat.Client.States;
using TestChat.Shared.DTOs;

namespace TestChat.Client.Services.MessageServiceFold
{
    public interface IMessageService
    {
        Task<bool> SendMessage(MessageSendDto messageDto, AuthenticationState authState);
    }
}
