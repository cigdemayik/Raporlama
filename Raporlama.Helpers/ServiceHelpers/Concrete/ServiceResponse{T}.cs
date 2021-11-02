using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Raporlama.Helpers.ServiceHelpers.Concrete
{
    public class ServiceResponse<TResult> : ServiceResponse
    {
        public ServiceResponse(TResult result, bool isSuccessful = true,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Result = result;
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
        }
        public ServiceResponse(TResult result, string errorMessage, bool isSuccessful = false,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Result = result;
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
        public TResult Result { get; set; }
    }
}
