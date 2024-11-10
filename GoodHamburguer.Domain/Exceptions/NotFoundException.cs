using System.Net;

namespace GoodHamburguer.Domain.Exceptions
{
    public class NotFoundException : GoodHamburguerException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override IList<string> GetErrorMessages()
        {
            return [Message];
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}
