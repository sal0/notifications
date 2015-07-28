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
        public dynamic AddMessage(AddMessageModel model)
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

                int userId;
                using (var bo = new UserBusinessObject())
                {
                    var user = bo.GetList(x => x.ApplicationId == model.ApplicationId && x.ExternalUserId == model.ExternalUserId).FirstOrDefault();
                    if (user == null)
                        throw new Exception("User not found");

                    userId = user.Id;
                }

                var message = new Message
                {
                    UserId = userId,
                    ProviderId = model.ProviderId,
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
    }
}
