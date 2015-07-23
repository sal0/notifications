using AltaSoft.Notifications.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltaSoft.Notifications.DAL;
using SendGrid;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.ComponentModel.Composition;

namespace AltaSoft.Notifications.Service.ProviderManagers
{
    [Export(typeof(IProviderManager))]
    public class SendGridProviderManager : IProviderManager
    {
        public int Id
        {
            get { return 1; }
        }

        public async Task<ProviderProcessResult> Process(Message message)
        {
            try
            {
                var msg = new SendGridMessage();
                msg.AddTo(message.User.Email);
                msg.From = new MailAddress(message.User.Application.EmailFromAddress, message.User.Application.EmailFromFullName);
                msg.Subject = message.Subject;
                msg.Html = message.Content;

                var transportWeb = new Web(ConfigurationManager.AppSettings["SendGridSecretKey"]);

                await transportWeb.DeliverAsync(msg);

                return new ProviderProcessResult { IsSuccess = true };
            }
            catch (Exceptions.InvalidApiRequestException ex)
            {
                return new ProviderProcessResult { IsSuccess = false, ErrorMessage = String.Join(",", ex.Errors), ErrorDetails = ex.ToString() };
            }
            catch (Exception ex)
            {
                return new ProviderProcessResult { IsSuccess = false, ErrorMessage = ex.Message, ErrorDetails = ex.ToString() };
            }
        }
    }
}
