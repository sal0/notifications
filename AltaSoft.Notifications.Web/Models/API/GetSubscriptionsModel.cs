using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class GetSubscriptionsModel : ApplicationCredentialsModel
    {
        public string EventKeys { get; set; }
        public string ExternalUserKeys { get; set; }
        public string ProviderIds { get; set; }
    }
}