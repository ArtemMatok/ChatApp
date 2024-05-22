using Microsoft.AspNetCore.Components;
using TestChat.Shared.Data;

namespace TestChat.Client.Services.MediaAccountServiceFold
{
    public interface IMediaAccountService
    {
        Task<MediaAccount> GetAccountById(int id);
        Task<MediaAccount> GetAccountByUserName(string userName);
        Task<bool> UpdateMediaAccount(string userName, MediaAccount mediaAccount);  
    }
}
