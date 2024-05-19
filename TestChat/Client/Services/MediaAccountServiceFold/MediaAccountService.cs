using System.Net.Http.Json;
using TestChat.Shared.Data;

namespace TestChat.Client.Services.MediaAccountServiceFold
{
    public class MediaAccountService : IMediaAccountService
    {
        private readonly HttpClient _httpClient;

        public MediaAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MediaAccount> GetAccountById(int id)
        {
            return await _httpClient.GetFromJsonAsync<MediaAccount>($"api/MediAccount/GetById/{id}");
        }
    }
}
