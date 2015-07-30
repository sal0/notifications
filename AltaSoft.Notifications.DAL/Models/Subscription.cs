using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL
{
    /// <summary>
    /// Subscriptions for sending easily to groups of users
    /// </summary>
    public class Subscription : ModelBase
    {
        [Index("IX_Event_User_Provider", 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Index("IX_Event_User_Provider", 2)]
        public int UserId { get; set; }
        public User User { get; set; }

        [Index("IX_Event_User_Provider", 3)]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
