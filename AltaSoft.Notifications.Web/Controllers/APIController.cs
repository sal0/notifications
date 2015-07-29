using AltaSoft.Notifications.DAL;
using AltaSoft.Notifications.Web.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltaSoft.Notifications.Web.Controllers
{
    public class APIController : ApiController
    {
        [HttpPost]
        public dynamic Send(SendModel model)
        {
            try
            {
                if (model == null)
                    throw new Exception("Please pass model");

                using (var bo = new ApplicationBusinessObject())
                {
                    if (!bo.Check(model.ApplicationId, model.ApplicationSecretKey))
                        throw new Exception("Invalid application credentials");
                }

                if (String.IsNullOrEmpty(model.Content))
                    throw new Exception("Content can't be empty");


                using (var bo = new ProviderBusinessObject())
                {
                    var provider = bo.GetById(model.ProviderId);
                    if (provider == null)
                        throw new Exception("Provider not found");
                }



                if (model.ExternalUserIds == null)
                    model.ExternalUserIds = new List<string>();

                if (!String.IsNullOrEmpty(model.ExternalUserId))
                    model.ExternalUserIds.Add(model.ExternalUserId);

                var userInfos = GetUserInfos(model.ApplicationId, model.ExternalUserIds, model.ProviderId);

                if (!String.IsNullOrEmpty(model.To))
                    userInfos.Add(new Tuple<int?, string>(null, model.To));


                if (userInfos.Count == 0)
                    throw new Exception("Please set: ExternalUserId, ExternalUserIds, or To");


                foreach (var info in userInfos)
                {
                    var message = new Message
                    {
                        UserId = info.Item1,
                        To = info.Item2,
                        ProviderId = model.ProviderId,
                        ApplicationId = model.ApplicationId,
                        Subject = model.Subject,
                        Content = model.Content,
                        ProcessDate = model.ProcessDate,
                        Priority = model.Priority ?? MessagePriority.Normal
                    };

                    using (var bo = new MessageBusinessObject())
                    {
                        bo.Create(message);
                    }
                }

            }
            catch (Exception ex)
            {
                return new { Error = ex.Message, ErrorDetails = ex.ToString() };
            }

            return new { IsSuccess = true };
        }

        [HttpPost]
        public dynamic SaveUser(SaveUserModel model)
        {
            try
            {
                if (model == null)
                    throw new Exception("Please pass model");

                using (var bo = new ApplicationBusinessObject())
                {
                    if (!bo.Check(model.ApplicationId, model.ApplicationSecretKey))
                        throw new Exception("Invalid application credentials");
                }


                var user = new User
                {
                    ApplicationId = model.ApplicationId,
                    ExternalUserId = model.ExternalUserId,
                    FirstName = model.FirstName,
                    FullName = model.FullName,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber
                };

                using (var bo = new UserBusinessObject())
                {
                    bo.Save(user);
                }

            }
            catch (Exception ex)
            {
                return new { Error = ex.Message, ErrorDetails = ex.ToString() };
            }

            return new { IsSuccess = true };
        }

        [HttpPost]
        public dynamic SaveUsers(SaveUsersModel model)
        {
            try
            {
                if (model == null)
                    throw new Exception("Please pass model");

                using (var bo = new ApplicationBusinessObject())
                {
                    if (!bo.Check(model.ApplicationId, model.ApplicationSecretKey))
                        throw new Exception("Invalid application credentials");
                }


                foreach (var item in model.Users)
                {
                    var user = new User
                    {
                        ApplicationId = model.ApplicationId,
                        ExternalUserId = item.ExternalUserId,
                        FirstName = item.FirstName,
                        FullName = item.FullName,
                        Email = item.Email,
                        MobileNumber = item.MobileNumber
                    };

                    using (var bo = new UserBusinessObject())
                    {
                        bo.Save(user);
                    }
                }


            }
            catch (Exception ex)
            {
                return new { Error = ex.Message, ErrorDetails = ex.ToString() };
            }

            return new { IsSuccess = true };
        }


        List<Tuple<int?, string>> GetUserInfos(int applicationId, List<string> externalUserIds, int providerId)
        {
            var result = new List<Tuple<int?, string>>();

            foreach (var item in externalUserIds)
            {
                using (var bo = new UserBusinessObject())
                {
                    var user = bo.GetList(x => x.ApplicationId == applicationId && x.ExternalUserId == item).FirstOrDefault();
                    if (user == null)
                        continue;

                    var to = GetToByProvider(user, providerId);
                    if (String.IsNullOrEmpty(to))
                        continue;

                    result.Add(new Tuple<int?, string>(user.Id, to));
                }
            }

            return result;
        }

        string GetToByProvider(User user, int providerId)
        {
            switch (providerId)
            {
                case 1: return user.Email;
                case 2: return user.MobileNumber;
                case 3: return user.ExternalUserId;
                case 4: return user.Email;
                default: return String.Empty;
            }
        }
    }
}
