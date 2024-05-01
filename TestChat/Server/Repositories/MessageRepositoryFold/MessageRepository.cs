using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<MessageDto>> GetMessages(int otherUserId, int userId)
        {
            var messages = await _context.Messages.AsNoTracking()
                .Where(x => (x.FromId == otherUserId && x.ToId == userId)
                ||(x.ToId==otherUserId && x.FromId == userId))
                .Select(x=> new MessageDto(x.ToId, x.FromId, x.Content,x.SentOn))
                .ToListAsync();
            return messages;
        }

        public async Task<MessageDto> SendMessage(MessageSendDto messageDto,int userId)
        {
            if (messageDto.ToUserId <= 0 || string.IsNullOrWhiteSpace(messageDto.Message))
                return null;
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
                var responseMessageDto = new MessageDto(message.ToId, message.FromId, message.Content,message.SentOn);
                return responseMessageDto;
            }
            else
            {
                return null;
            }
        }

        
    }
}
