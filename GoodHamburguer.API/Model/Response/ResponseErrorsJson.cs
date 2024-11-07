namespace GoodHamburguer.API.Model.Response
{
    public class ResponseErrorsJson
    {
        public IList<string> Errors { get; set; } = [];

        public ResponseErrorsJson(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
