using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL
{
    /// <summary>
    /// Message Template for frequent items
    /// </summary>
    public class Template : ModelBase
    {
        /// <summary>
        /// Templated Content
        /// </summary>
        public string Content { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
