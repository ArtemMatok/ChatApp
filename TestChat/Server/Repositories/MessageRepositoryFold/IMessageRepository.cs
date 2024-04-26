using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.MessageRepositoryFold
{
    public interface IMessageRepository
    {
        Task<bool> SendMessage(MessageSendDto messageDto, int userId);
    }
}
