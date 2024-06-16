using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.Account.NotificationFold
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public string NotificationMessage { get; set; }
    }
}
