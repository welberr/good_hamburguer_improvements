namespace GoodHamburguer.API.Model.Response
{
    public class ErrorsResponseModel
    {
        public IList<string> Errors { get; set; } = [];

        public ErrorsResponseModel(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
