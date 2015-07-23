using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AltaSoft.Notifications.DAL
{
    public class ApplicationBusinessObject : BusinessObjectBase<Application>
    {
        public bool Check(int id, string secretKey)
        {
            return db.Applications.FirstOrDefault(x => x.Id == id && x.SecretKey == secretKey) != null;
        }
    }
}
