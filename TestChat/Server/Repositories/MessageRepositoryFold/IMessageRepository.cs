﻿using TestChat.Server.Data.Entities;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.MessageRepositoryFold
{
    public interface IMessageRepository
    {
        Task<MessageDto> SendMessage(MessageSendDto messageDto, int userId);
        Task<IEnumerable<MessageDto>> GetMessages(int otherUserId, int userId);
    }
}
