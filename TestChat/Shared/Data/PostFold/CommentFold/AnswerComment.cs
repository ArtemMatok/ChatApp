using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.PostFold.CommentFold
{
    public class AnswerComment
    {
        public int AnswerCommentId { get; set; }
        public string UserName { get; set; }
        public string MediaAccountPhoto { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Content { get; set; }
    }
}
