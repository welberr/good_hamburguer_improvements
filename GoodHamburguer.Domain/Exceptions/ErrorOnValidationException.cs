using System.Net;

namespace GoodHamburguer.Domain.Exceptions
{
    public class ErrorOnValidationException : SystemException
    {
        private readonly string _error;
        private readonly HttpStatusCode _statusCode;

        public ErrorOnValidationException
        (
            string error,
            HttpStatusCode statusCode
        )
        {
            _error = error;
            _statusCode = statusCode;
        }

        public string GetErrorMessage()
        {
            return _error;
        }

        public HttpStatusCode GetStatusCode()
        {
            return _statusCode;
        }
    }
}
