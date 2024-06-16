using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChat.Shared.Data.Account.NotificationFold
{
    public class NotificationState
    {
        public event Action OnChange;

        private int notificationCount;

        public int NotificationCount
        {
            get => notificationCount;
            set
            {
                if (notificationCount != value)
                {
                    notificationCount = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
