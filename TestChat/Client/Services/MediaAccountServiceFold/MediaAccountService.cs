using System.Net.Http.Json;
using TestChat.Shared.Data;
using TestChat.Shared.Data.PostFold;

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
            try
            {
                var mediaAccount = await _httpClient.GetFromJsonAsync<MediaAccount>($"api/MediAccount/GetById/{id}");
                
                if( mediaAccount == null )
                {
                    throw new Exception("Account wasn`t found");
                }
                return mediaAccount;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching the post: {ex.Message}", ex);
            }
          
        }

        public async Task<MediaAccount> GetAccountByUserName(string userName)
        {
            try
            {
                var account = await _httpClient.GetFromJsonAsync<MediaAccount>($"api/MediAccount/GetByUserName/{userName}");
                if (account is  null)
                {
                    throw new Exception("Account wasn`t found");
                }
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching the post: {ex.Message}", ex);
            }
            
          
        }

        public async Task<bool> UpdateMediaAccount(string userName, MediaAccount mediaAccountUpdate)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/MediAccount/UpdateAccount/{userName}", mediaAccountUpdate);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateMediaAccountByPost(string userName, Post post)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/MediAccount/UpdateAccountByPost/{userName}", post);

            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;   
        }
    }
}
