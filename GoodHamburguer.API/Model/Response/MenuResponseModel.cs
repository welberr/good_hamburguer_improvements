namespace GoodHamburguer.API.Model.Response
{
    public class MenuResponseModel
    {
        public List<SandwichResponseModel> Sandwich { get; set; }
        public ExtraResponseModel Extra { get; set; }
    }
}
