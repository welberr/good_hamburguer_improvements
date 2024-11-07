using System.Net;

namespace GoodHamburguer.Domain.Exceptions
{
    public class ErrorsOnValidationException : SystemException
    {
        private readonly IList<string> _errors;
        private readonly HttpStatusCode _statusCode;

        public ErrorsOnValidationException
        (
            IList<string> errors,
            HttpStatusCode statusCode
        )
        {
            _errors = errors;
            _statusCode = statusCode;
        }

        public IList<string> GetErrorMessages()
        {
            return _errors;
        }

        public HttpStatusCode GetStatusCode()
        {
            return _statusCode;
        }
    }
}
