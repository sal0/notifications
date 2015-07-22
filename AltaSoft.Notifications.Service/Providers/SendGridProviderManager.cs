using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;

namespace AltaSoft.Notifications.Service.Providers
{
    public class SendGridProviderManager : ProviderManagerBase
    {
        public override int Id
        {
            get { return 1; }
        }

        public override async Task<ProviderProcessResult> Process(string to, string content, Application application)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return new ProviderProcessResult { IsSuccess = true };
        }
    }
}
