using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TestChat.Shared.DTOs;
using System.Net.Http.Headers;
using TestChat.Client.States;


namespace TestChat.Client.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetUsers(AuthenticationState authState)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authState.Token);

            return await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("/api/User/GetUsers", TestChat.Shared.Helpers.JsonConverter.JsonSerializerOptions);
        }

        public async Task<IList<UserDto>> GetUsersChats()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDto>>("/api/User/Chats", TestChat.Shared.Helpers.JsonConverter.JsonSerializerOptions);
        }
    }
}
