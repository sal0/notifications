using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Models
{
    /// <summary>
    /// Event for subscribing UserGroup
    /// </summary>
    public class Event : ModelBase
    {
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }
    }
}
