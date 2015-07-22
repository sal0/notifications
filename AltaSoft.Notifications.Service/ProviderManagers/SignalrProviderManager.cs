using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;

namespace AltaSoft.Notifications.Service.ProviderManagers
{
    public class SignalrProviderManager : IProviderManager
    {
        public int Id
        {
            get { return 3; }
        }

        public async Task<ProviderProcessResult> Process(Message message)
        {
            throw new NotImplementedException("yet");
        }
    }
}
