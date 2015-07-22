using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL
{
    /// <summary>
    /// Notification providers, SendGrid, SMS, SignalR, etc.
    /// </summary>
    public class Provider : ModelBase
    {
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }
    }
}
