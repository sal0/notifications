﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class SaveUserModel
    {
        public int ApplicationId { get; set; }
        public string ApplicationSecretKey { get; set; }

        public string ExternalUserId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}