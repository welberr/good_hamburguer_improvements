using System.Net;

namespace GoodHamburguer.Domain.Exceptions
{
    public abstract class GoodHamburguerException : SystemException
    {
        public GoodHamburguerException(string message) : base(message) 
        {
            
        }

        public abstract HttpStatusCode GetStatusCode();
        public abstract IList<string> GetErrorMessages();
    }
}
