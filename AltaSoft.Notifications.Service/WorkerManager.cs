using AltaSoft.Notifications.DAL;
using AltaSoft.Notifications.Service.Common;
using AltaSoft.Notifications.Service.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AltaSoft.Notifications.Service
{
    public class WorkerManager
    {
        MessagePriority Priority;
        List<IProviderManager> ProviderManagers { get; set; }

        public WorkerManager(MessagePriority priority = MessagePriority.Normal)
        {
            Priority = priority;

            ProviderManagers = new List<IProviderManager>();
            ProviderManagers.Add(new SendGridProviderManager());
            ProviderManagers.Add(new SMSProviderManager());
        }

        public async Task Process()
        {
            using (var bo = new MessageBusinessObject())
            {
                // 1. Get messages to be proceeded
                var items = bo.GetList(x =>
                                x.Priority == Priority
                                && (x.State == MessageStates.Pending || x.State == MessageStates.ProviderManagerNotFound)
                                && (x.ProcessDate == null || x.ProcessDate <= DateTime.Now));


                // 2. Process them all
                foreach (var item in items)
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
                        var result = await pm.Process(item);

                        item.State = result.IsSuccess ? MessageStates.Success : MessageStates.Fail;
                        item.RetryCount++;
                        item.ErrorMessage = result.ErrorMessage;
                        item.ErrorDetails = result.ErrorDetails;

                        bo.Update(item);

                        tran.Complete();
                    }
                }
            }
        }
    }
}
