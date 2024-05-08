using System.Net.Http.Json;
using System.Text.Json;
using TestChat.Client.States;
using TestChat.Shared.DTOs;

namespace TestChat.Client.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationState _authState;
        public AccountService(HttpClient httpClient, AuthenticationState authState)
        {
            _httpClient = httpClient;
            _authState = authState;
        }

        public async Task<HttpResponseMessage> Login(LoginDto loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginDto>("/api/Account/Login", loginModel);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var authResult = JsonSerializer.Deserialize<AuthResponseDto>(content, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    
                });
                _authState.LoadState(authResult);
                return response;
            }
            else
            {
                string errorContent = null;
                try
                {
                    errorContent = await response.Content.ReadAsStringAsync();
                }
                catch
                {
                }
                //if(string.IsNullOrWhiteSpace(errorContent))
                //{
                //    errorContent = $"Error {response.StatusCode} - ${response.ReasonPhrase}";
                //}
                return response;
            }
            
        }

        public async Task<bool> Register(RegisterDto registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync<RegisterDto>("/api/Account/Register", registerModel);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var authResult = JsonSerializer.Deserialize<AuthResponseDto>(content, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                });
                
                return true;
            }
            else
            {
                string errorContent = null;
                try
                {
                    errorContent = await response.Content.ReadAsStringAsync();
                }
                catch
                {
                }
              
                return false;
            }
        }
    }
}
