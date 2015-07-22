using AltaSoft.Notifications.DAL;
using AltaSoft.Notifications.Service.Common;
using AltaSoft.Notifications.Service.ProviderManagers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AltaSoft.Notifications.Service
{
    public class WorkerManager
    {
        const string EventLogKey = "AltaSoft.Notifications.Service";

        MessagePriority Priority;
        List<IProviderManager> ProviderManagers;
        bool IsStarted;

        TimeSpan Delay
        {
            get
            {
                return (Priority == MessagePriority.High) ? TimeSpan.FromMilliseconds(50) : TimeSpan.FromMilliseconds(2000);
            }
        }


        public WorkerManager(MessagePriority priority = MessagePriority.Normal)
        {
            Priority = priority;

            ProviderManagers = new List<IProviderManager>();
            ProviderManagers.Add(new SendGridProviderManager());
            ProviderManagers.Add(new SMSProviderManager());
            ProviderManagers.Add(new SignalrProviderManager());
        }


        public async Task Start()
        {
            IsStarted = true;

            while (IsStarted)
            {
                try
                {
                    await Process();
                    await Task.Delay(Delay);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(EventLogKey, String.Format("Process Error {0}", ex));
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
        }

        public async Task Process()
        {
            using (var bo = new MessageBusinessObject())
            {
                // 1. Get messages to be proceeded
                var items = await bo.GetListToBeProceeded(x => x.Priority == Priority);


                // 2. Process them all
                foreach (var item in items)
                {
                    try
                    {
                        var pm = ProviderManagers.FirstOrDefault(x => x.Id == item.ProviderId);
                        if (pm == null)
                        {
                            item.State = MessageStates.ProviderManagerNotFound;
                            bo.Update(item);
                            return;
                        }

                        using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                        {
                            var processStartDate = DateTime.Now;
                            try
                            {
                                var result = await pm.Process(item);

                                var duration = DateTime.Now - processStartDate;

                                item.ProcessingDuration = Convert.ToInt32(duration.TotalMilliseconds);
                                item.State = result.IsSuccess ? MessageStates.Success : MessageStates.Failed;
                                item.RetryCount++;
                                item.ErrorMessage = result.ErrorMessage;
                                item.ErrorDetails = result.ErrorDetails;
                            }
                            catch (Exception ex)
                            {
                                item.State = MessageStates.Failed;
                                item.ErrorMessage = ex.Message;
                                item.ErrorDetails = ex.ToString();
                            }

                            bo.Update(item);

                            tran.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(EventLogKey, String.Format("Processing Item: {0}, Error: {1}", item.Id, ex));
                    }
                }
            }
        }

        public void Stop()
        {
            IsStarted = false;
        }
    }
}
