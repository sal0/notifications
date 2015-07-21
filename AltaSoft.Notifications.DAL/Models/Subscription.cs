using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Models
{
    /// <summary>
    /// Subscriptions for sending easily to groups of users
    /// </summary>
    public class Subscription : ModelBase
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
