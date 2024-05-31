using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.PostFold
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Photo is required")]
        public string ImageUrl { get; set; }
        public int Likes { get; set; } = 0;

        public string Access;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
