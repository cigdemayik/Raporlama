using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Raporlama.Helpers.ServiceHelpers.Concrete
{
    public class ServiceResponse
    {
        public ServiceResponse(bool isSuccessful = true,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
        }
        public ServiceResponse(
            string errorMessage,
            bool isSuccessful = true,
            HttpStatusCode statusCode = HttpStatusCode.OK
            )
        {
            ErrorMessage = errorMessage;
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
        }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}

