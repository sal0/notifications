using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Models
{
    /// <summary>
    /// Group of users
    /// </summary>
    public class UserGroup : ModelBase
    {
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }

        public List<int> Users { get; set; }
    }
}
