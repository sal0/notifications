using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;
using System.ComponentModel.Composition;

namespace AltaSoft.Notifications.Service.ProviderManagers
{
    [Export(typeof(IProviderManager))]
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
