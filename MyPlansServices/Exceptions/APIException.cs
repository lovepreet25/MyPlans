using MyPlansLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansServices.Exceptions

{
    public class APIException : Exception
    {
        public ApiErrorsResponses ApiErrorsResponses { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public APIException(ApiErrorsResponses error, HttpStatusCode statusCode) :  this (error)
        {
            StatusCode = statusCode;
        }

        public APIException(ApiErrorsResponses error)
        {
            ApiErrorsResponses = error;
        }
    }
}
