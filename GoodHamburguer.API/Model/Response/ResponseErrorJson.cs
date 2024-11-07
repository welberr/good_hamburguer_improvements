namespace GoodHamburguer.API.Model.Response
{
    public class ResponseErrorJson
    {
        public string Error { get; set; }

        public ResponseErrorJson(string error)
        {
            Error = error;
        }
    }
}
