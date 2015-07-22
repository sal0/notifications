using AltaSoft.Notifications.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service.Common
{
    public abstract class ProviderManagerBase
    {
        public abstract int Id { get; }

        public abstract Task<ProviderProcessResult> Process(string to, string content, Application application);
    }
}
