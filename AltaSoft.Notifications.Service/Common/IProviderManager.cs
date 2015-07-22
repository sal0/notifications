using AltaSoft.Notifications.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service.Common
{
    public interface IProviderManager
    {
        int Id { get; }

        Task<ProviderProcessResult> Process(Message message);
    }
}
