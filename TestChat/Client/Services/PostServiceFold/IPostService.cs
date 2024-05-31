using TestChat.Shared.Data.PostFold;

namespace TestChat.Client.Services.PostServiceFold
{
    public interface IPostService
    {
        Task<Post> GetPostById(int id);
    }
}
