using AltaSoft.Notifications.Service.Common;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = ConfigurationManager.AppSettings["SignalrUrl"];
            var worker = new WorkerManager(DAL.MessagePriority.Normal);

            worker.Start();
            
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }

        }
    }
}
