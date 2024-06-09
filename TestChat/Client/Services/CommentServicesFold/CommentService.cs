
using System.Net.Http.Json;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Client.Services.CommentServicesFold
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var result = await _httpClient.DeleteAsync($"api/Comment/DeleteComment/{commentId}");

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Comment>($"api/Comment/GetCommentById/{commentId}");

                if(result == null)
                {
                    throw new Exception("Comment wasn`t found");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting comment: {ex.Message}", ex);
            }
           
        }

        public async Task<List<Comment>> GetCommentByPost(int postId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Comment>>($"api/Comment/GetCommentsByPost/{postId}");

            if(result == null)
            {
                return new List<Comment>();
            }

            return result;
        }

        public async Task<bool> UpdateCommentByAnswerComments(int commentId, Comment answerComment)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Post/UpdateCommentByAnswerComments/{commentId}", answerComment);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateCommentByLike(int commentId, Comment commentUpdated)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Comment/UpdateCommentByLike/{commentId}", commentUpdated);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;   
           
        }
    }
}
