using iCheap.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace iCheap.WebApp
{
    public class NotImplExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var responseData = new Response<DBNull>
            {
                Status = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrMess = "Invalid request: " + context.Exception.Message,
            };
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, responseData);
            base.OnException(context);
        }
    }
}