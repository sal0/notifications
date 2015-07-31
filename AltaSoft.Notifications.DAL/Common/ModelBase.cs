using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Common
{
    public class ModelBase
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
