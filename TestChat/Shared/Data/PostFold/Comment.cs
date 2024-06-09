using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChat.Shared.Data.PostFold.CommentFold;

namespace TestChat.Shared.Data.PostFold
{
    public class Comment
    {
        public Comment(string userName, string mediaAccountPhoto, string content,int postId)
        {
            UserName = userName;
            MediaAccountPhoto = mediaAccountPhoto;
            Content = content;
            PostId = postId;
        }
        public Comment()
        {
                
        }

        public int Id { get; set; }
        public int PostId { get; set; }
       
        public string UserName { get; set; }
        public string MediaAccountPhoto { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Content { get; set; }
        public List<CommentLike> Likes { get; set; } = new List<CommentLike>();
        public List<Comment> AnswerComments { get; set; } = new List<Comment>();
        [NotMapped]        
        public bool IsOpenAnswerComments { get; set; }
       
    }
}
