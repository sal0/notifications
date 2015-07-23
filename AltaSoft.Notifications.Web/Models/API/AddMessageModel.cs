using AltaSoft.Notifications.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class AddMessageModel
    {
        public int ApplicationId { get; set; }
        public string ApplicationSecretKey { get; set; }

        public string ExternalUserId { get; set; }
        public int ProviderId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime? ProcessDate { get; set; }
        public MessagePriority? Priority { get; set; }
    }
}