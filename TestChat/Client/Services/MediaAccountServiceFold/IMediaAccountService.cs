using Microsoft.AspNetCore.Components;
using TestChat.Shared.Data;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Client.Services.MediaAccountServiceFold
{
    public interface IMediaAccountService
    {
        Task<MediaAccount> GetAccountById(int id);
        Task<MediaAccount> GetAccountByUserName(string userName);
        Task<bool> UpdateMediaAccount(string userName, MediaAccount mediaAccount);
        Task<bool> UpdateMediaAccountByPost(string userName, Post post);
        Task<bool> UpdateMediaAccountByFolowAccount(string userNameCurrent, MediaAccount mediaAccountFollowing);
        Task<List<MediaAccount>> GetMediaAccountsByPost(int id);
        Task<List<MediaAccount>> GetAllMediaAccounts();
         Task<List<MediaAccount>> GetAllMediaAccountWithoutCurrent(string userNameCurrent);


    }
}
