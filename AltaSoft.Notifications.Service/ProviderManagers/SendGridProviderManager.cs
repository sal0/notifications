using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;

namespace AltaSoft.Notifications.Service.ProviderManagers
{
    public class SendGridProviderManager : IProviderManager
    {
        public int Id
        {
            get { return 1; }
        }

        public async Task<ProviderProcessResult> Process(Message message)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return new ProviderProcessResult { IsSuccess = true };
        }
    }
}
