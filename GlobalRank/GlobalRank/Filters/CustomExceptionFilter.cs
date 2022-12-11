using GlobalRank.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GlobalRank.Filters
{
    public class CustomExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            HandleException(context);
        }

        private void HandleException(ActionExecutedContext context)
        {
            var exception = context.Exception;
            if (exception == null)
            {
                return;
            }

            var message = string.Empty;
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var exceptionType = exception.GetType();
            var exceptionMessage = exception.Message;

            if (exceptionType == typeof(AggregateException))
            {
                bool mustReturn = false;
                (exception as AggregateException).Handle((x) =>
                {
                    context.Exception = x;
                    if (x.GetType() != typeof(AggregateException))
                    {
                        mustReturn = true;
                        HandleException(context);
                    }

                    return true;
                });

                if (mustReturn) return;
            }

            if (exceptionType == typeof(ArgumentException))
            {
                message = exceptionMessage;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(DataNotFoundException))
            {
                message = exceptionMessage;
                status = HttpStatusCode.NotFound;
            }
            else
            {
                message = "Unknown error occured.";
                status = HttpStatusCode.InternalServerError;
            }

            context.Result = new ObjectResult(message)
            {
                StatusCode = (int?)status
            };

            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
