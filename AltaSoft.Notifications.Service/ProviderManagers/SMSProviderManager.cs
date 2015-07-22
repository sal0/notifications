using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;

namespace AltaSoft.Notifications.Service.ProviderManagers
{
    public class SMSProviderManager : IProviderManager
    {
        public int Id
        {
            get { return 2; }
        }

        public async Task<ProviderProcessResult> Process(Message message)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

            return new ProviderProcessResult { IsSuccess = true };
        }
    }
}
