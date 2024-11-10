using System.Net;

namespace GoodHamburguer.Domain.Exceptions
{
    public class ErrorOnValidationException : GoodHamburguerException
    {
        private readonly IList<string> _errors;

        public ErrorOnValidationException
        (
            IList<string> errors

        ) : base(string.Empty)
        {
            _errors = errors;
        }

        public override IList<string> GetErrorMessages()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
