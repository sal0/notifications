using AltaSoft.Notifications.DAL.Context;
using AltaSoft.Notifications.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MainContext())
            {
                db.Providers.Add(new Provider { Name = "SendGrid", RegDate = DateTime.Now });
                db.Providers.Add(new Provider { Name = "SMS", RegDate = DateTime.Now });
                db.Providers.Add(new Provider { Name = "SignalR", RegDate = DateTime.Now });

                db.SaveChanges();
            }
        }
    }
}
