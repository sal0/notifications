using AltaSoft.Notifications.DAL;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.Service.Hubs
{
    public class RealtimeHub : Hub
    {
        const string QUERY_STRING_APPLICATION_KEY = "appid";
        const string QUERY_STRING_TOKEN_KEY = "token";


        public string GroupName { get; set; }


        public override async Task OnConnected()
        {
            var externalApplicationIdString = Context.QueryString[QUERY_STRING_APPLICATION_KEY];
            var externalUserToken = Context.QueryString[QUERY_STRING_TOKEN_KEY];
            var externalUserIPAddress = GetIPAddress();
            var externalUserId = await GetExternalUserId(externalUserToken, externalUserIPAddress);

            int externalApplicationId;

            if (!Int32.TryParse(externalApplicationIdString, out externalApplicationId) || String.IsNullOrWhiteSpace(externalUserId))
                return;


            // Check if user exists in our database
            using (var bo = new UserBusinessObject())
            {
                var user = bo.GetList(x => x.ApplicationId == externalApplicationId && x.ExternalUserId == externalUserId).FirstOrDefault();
                if (user == null) return;
            }

            GroupName = externalApplicationId + externalUserId;


            await Groups.Add(Context.ConnectionId, GroupName);

            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            await Groups.Remove(Context.ConnectionId, GroupName);

            await base.OnDisconnected(stopCalled);
        }



        async Task<string> GetExternalUserId(string token, string ipaddress)
        {
            return "";
        }

        string GetIPAddress()
        {
            return "";
        }
    }
}
