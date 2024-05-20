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

        public async Task<MediaAccount> GetAccountByUserName(string userName)
        {
            var account = await _httpClient.GetFromJsonAsync<MediaAccount>($"api/MediAccount/GetByUserName/{userName}");
            if (account is not null)
            {
                return account;
            }
            else
            {
                return null;
            }
        }
    }
}
