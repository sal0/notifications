using AltaSoft.Notifications.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service
{
    public class MessagesManager
    {
        MessagePriority Priority;

        public MessagesManager(MessagePriority priority = MessagePriority.Normal)
        {
            Priority = priority;
        }

        public void Process()
        {
            // 1. Get messages to be proceeded
            using (var bo = new MessageBusinessObject())
            {
                var items = bo.GetList(x => x.Priority == Priority && (x.ProcessDate == null || x.ProcessDate <= DateTime.Now));


                // 2. Process them all
                foreach (var item in items)
                {

                }
            }
        }
    }
}
