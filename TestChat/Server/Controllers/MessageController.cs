using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TestChat.Server.Data.Entities;
using TestChat.Server.Hubs;
using TestChat.Server.Repositories.MessageRepositoryFold;
using TestChat.Shared.Chat;
using TestChat.Shared.DTOs;

namespace TestChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHubContext<BlazingChatHub, IBlazingChatHubClient> _hubContext;



        public MessageController(IMessageRepository messageRepository, IHubContext<BlazingChatHub, IBlazingChatHubClient> hubContext)
        {
            _messageRepository = messageRepository;
            _hubContext = hubContext;
        }


        [HttpPost("SendMessage")]
        public async Task <IActionResult> SendMessage(MessageSendDto messageDto)
        {
            var result = await _messageRepository.SendMessage(messageDto, UserId);
            if(result is not null)
            {

                await _hubContext.Clients.User(messageDto.ToUserId.ToString()).MessageReceived(result);
                return Ok();
            }
            else
            {
                return StatusCode(500, "Unable to send message");
            }
        }

        [HttpGet("GetMessages/{otherUserId:int}")]
        public async Task<IEnumerable<MessageDto>> GetMessages(int otherUserId)
        {
            return await _messageRepository.GetMessages(otherUserId, UserId);
        }
    }
}
