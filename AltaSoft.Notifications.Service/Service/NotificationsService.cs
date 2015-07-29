using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service.Service
{
    partial class NotificationsService : ServiceBase
    {
        WorkerManager worker;
        WorkerManager worker2;
        IDisposable webApp;

        public NotificationsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            var url = ConfigurationManager.AppSettings["SignalrUrl"];
            worker = new WorkerManager(DAL.MessagePriority.Normal);
            worker2 = new WorkerManager(DAL.MessagePriority.High);

            worker.Start();
            worker2.Start();

            webApp = WebApp.Start(url);
        }

        protected override void OnStop()
        {
            worker.Stop();
            worker2.Stop();
            webApp.Dispose();
        }
    }
}
