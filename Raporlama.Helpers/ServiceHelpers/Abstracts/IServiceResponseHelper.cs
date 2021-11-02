using Raporlama.Helpers.ServiceHelpers.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Raporlama.Helpers.Abstracts
{
    public interface IServiceResponseHelper
    {
        ServiceResponse SetError(string errorMessage, HttpStatusCode statusCode);
        ServiceResponse<T> SetError<T>(T data, string errorMessage, HttpStatusCode statusCode);
        ServiceResponse SetSuccess(HttpStatusCode statusCode);
        ServiceResponse<T> SetSuccess<T>(T data, HttpStatusCode statusCode);
    }
}
