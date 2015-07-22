using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;

namespace AltaSoft.Notifications.Service.Providers
{
    public class SMSProviderManager : IProviderManager
    {
        public override int Id
        {
            get { return 2; }
        }

        public override async Task<ProviderProcessResult> Process(string to, string content, Application application)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return new ProviderProcessResult { IsSuccess = true };
        }
    }
}
