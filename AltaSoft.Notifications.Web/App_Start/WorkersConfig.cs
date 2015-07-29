using AltaSoft.Notifications.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web
{
    public class WorkersConfig
    {
        public static void Register()
        {
            if (ConfigurationManager.AppSettings["NotificationServiceWorkerEnabled"] == "true")
            {
                new WorkerManager(DAL.MessagePriority.Normal).Start();
                new WorkerManager(DAL.MessagePriority.High).Start();
            }
        }
    }
}