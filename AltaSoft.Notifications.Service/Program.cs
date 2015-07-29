using AltaSoft.Notifications.Service.Common;
using AltaSoft.Notifications.Service.Service;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(new[] { new NotificationsService() });
                return;
            }


            var url = ConfigurationManager.AppSettings["SignalrUrl"];
            var worker = new WorkerManager(DAL.MessagePriority.Normal);
            var worker2 = new WorkerManager(DAL.MessagePriority.High);

            worker.Start();
            worker2.Start();

            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }

        }
    }
}
