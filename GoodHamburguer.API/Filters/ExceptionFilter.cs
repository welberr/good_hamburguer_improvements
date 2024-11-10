using GoodHamburguer.API.Model.Response;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoodHamburguer.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not GoodHamburguerException)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                var responseUnknownError = new ErrorsResponseModel(new List<string> { ResourceExceptionMessages.UNKNOWN_ERROR });
                context.Result = new ObjectResult(responseUnknownError);
                return;
            }

            var errorsException = (GoodHamburguerException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)errorsException.GetStatusCode();
            var responseErrors = new ErrorsResponseModel(errorsException.GetErrorMessages());
            context.Result = new ObjectResult(responseErrors);
        }
    }
}
