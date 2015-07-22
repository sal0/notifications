using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL
{
    /// <summary>
    /// User from external system, who will receive notification
    /// </summary>
    public class User : ModelBase
    {
        /// <summary>
        /// First name if available
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Full name if available
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Mobile Number
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Id in External System, will be identified by this field, with application Id
        /// </summary>
        public string ExternalUserId { get; set; }

        public int? ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
