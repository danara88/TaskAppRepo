using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TaskApp.Core.Exceptions;

namespace TaskApp.Infrastructure.Filters
{
    /// <summary>
    /// Global exception filter
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Method to configure exception content
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Message = exception.Message
                };
                context.Result = new BadRequestObjectResult(validation);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
