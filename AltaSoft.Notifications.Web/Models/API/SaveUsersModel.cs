﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class SaveUsersModel : ApplicationCredentialsModel
    {
        public List<UserInfo> Users { get; set; }
    }

    public class UserInfo
    {
        public string ExternalUserId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}