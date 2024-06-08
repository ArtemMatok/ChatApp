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
        public int PostId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Photo is required")]
        public string ImageUrl { get; set; }
       
        public List<Like> LikesList { get; set; } = new List<Like>();
        public int Likes => LikesList.Count;

        public string Access { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
