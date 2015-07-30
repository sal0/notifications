using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltaSoft.Notifications.Web.Models.API
{
    public class APIResult
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public string ErrorDetails { get; set; }

        public APIResult()
        {
            IsSuccess = true;
        }

        public APIResult(string error, string errorDetails)
        {
            IsSuccess = false;
            Error = error;
            ErrorDetails = errorDetails;
        }
    }

    public class APIResult<T> : APIResult
    {
        public T Data { get; set; }

        public APIResult(T data) : base()
        {
            Data = data;
        }

        public APIResult(string error, string errorDetails) : base(error, errorDetails)
        {
        }
    }
}