using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class SubscribeUserModel : ApplicationCredentialsModel
    {
        public string ExternalUserId { get; set; }
        public string EventKey { get; set; }
        public string ProviderKey { get; set; }
    }
}