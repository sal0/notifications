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
    public class EventBusinessObject : BusinessObjectBase<Event>
    {
        public Event GetByKey(int applicationId, string key)
        {
            key = key.ToLower();

            return db.Events.AsNoTracking().FirstOrDefault(x => x.ApplicationId == applicationId && x.Key.ToLower() == key);
        }

        public void Save(Event entity)
        {
            var existingItem = this.GetList(x => x.ApplicationId == entity.ApplicationId && x.Key == entity.Key).FirstOrDefault();
            if (existingItem == null)
            {
                Create(entity);
                return;
            }


            entity.Id = existingItem.Id;
            entity.RegDate = existingItem.RegDate;

            Update(entity);
        }

        public void Delete(int applicationId, string key)
        {
            var entity = this.GetList(x => x.ApplicationId == applicationId && x.Key == key).FirstOrDefault();
            if (entity == null)
                return;

            this.Delete(entity);
        }
    }
}
