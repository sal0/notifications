using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Models
{
    /// <summary>
    /// Queue to process send requests
    /// </summary>
    public class QueueMessage : ModelBase
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public string Content { get; set; }

        public QueueMessageStates State { get; set; }
    }
}
