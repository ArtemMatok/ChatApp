using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.PostFold
{
    public class Like
    {
        public Like(string userNameAccount, int postId)
        {
            UserNameAccount = userNameAccount;
            PostId = postId;
           
        }

        public int Id { get; set; }
        public string UserNameAccount { get; set; }
        public int PostId { get; set; }
        public DateTime DateLiked { get; set; } = DateTime.Now;
    }
}
