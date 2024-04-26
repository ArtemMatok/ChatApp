using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TestChat.Client.States;
using TestChat.Shared.DTOs;

namespace TestChat.Client.Services.MessageServiceFold
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendMessage(MessageSendDto messageDto, AuthenticationState authState)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Message/SendMessage", messageDto, TestChat.Shared.Helpers.JsonConverter.JsonSerializerOptions);
            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
