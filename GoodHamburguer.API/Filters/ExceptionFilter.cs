using GoodHamburguer.API.Model.Response;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GoodHamburguer.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ErrorsOnValidationException)
            {
                var errorsException = (ErrorsOnValidationException)context.Exception;
                context.HttpContext.Response.StatusCode = (int)errorsException.GetStatusCode();
                var responseErrors = new ResponseErrorsJson(errorsException.GetErrorMessages());
                context.Result = new ObjectResult(responseErrors);
                return;
            }

            if (context.Exception is ErrorOnValidationException)
            {
                var errorException = (ErrorOnValidationException)context.Exception;
                context.HttpContext.Response.StatusCode = (int)errorException.GetStatusCode();
                var responseErrors = new ResponseErrorJson(errorException.GetErrorMessage());
                context.Result = new ObjectResult(responseErrors);
                return;
            }

            var responseJson = new ResponseErrorJson(ResourceExceptionMessages.UNKNOWN_ERROR);
            context.Result = new ObjectResult(responseJson);
        }
    }
}
