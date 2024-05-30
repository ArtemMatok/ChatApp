using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.PostFold
{
    public class Comment
    {
        public int Id { get; set; }
        public MediaAccount CommentSender { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Content { get; set; }


    }
}
