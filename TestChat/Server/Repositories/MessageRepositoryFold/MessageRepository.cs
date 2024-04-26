using TestChat.Server.Data;
using TestChat.Server.Data.Entities;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Repositories.MessageRepositoryFold
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SendMessage(MessageSendDto messageDto,int userId)
        {
            if (messageDto.ToUserId <= 0 || string.IsNullOrWhiteSpace(messageDto.Message))
                return false;
            var message = new Message()
            {
                FromId = userId,
                ToId = messageDto.ToUserId,
                Content = messageDto.Message,
                SentOn = DateTime.Now,
            };

            await _context.Messages.AddAsync(message);

            var result = await _context.SaveChangesAsync();

            if(result >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
