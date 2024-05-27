using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChat.Shared.Data.PostFold;

namespace TestChat.Shared.Data
{
    public class MediaAccount
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Your Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter Your User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Your Description")]
        public string Description { get; set; } = string.Empty;
        public string Photo { get; set; } = "https://i.ibb.co/rc0fPvM/4cdee02fbf6649b4e2c7b597f9d4d143.jpg";
        
        public List<MediaAccount> Following { get; set; } = new List<MediaAccount>();
        public List<MediaAccount> BestFriend { get; set; } = new List<MediaAccount>();

        public List<MediaAccount> Followers { get; set; } = new List<MediaAccount>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
