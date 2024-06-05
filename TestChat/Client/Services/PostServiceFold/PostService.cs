using System.Net.Http.Json;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Client.Services.PostServiceFold
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePost(int postId)
        {
            var result = await _httpClient.DeleteAsync($"api/Post/DeletePost/{postId}");
           if(result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Post> GetPostById(int id)
        {
            try
            {
                var post = await _httpClient.GetFromJsonAsync<Post>($"api/Post/GetPostById/{id}");

                if(post == null)
                {
                    throw new Exception("Post wasn`t found");
                }
                return post;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while fetching the post: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdatePost(int postId, Post post)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Post/Update/{postId}", post);

            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePostByComment(Post post)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Post/UpdatePostByPost", post);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePostByLike(Post post)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Post/UpdatePostByLike", post);

            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
