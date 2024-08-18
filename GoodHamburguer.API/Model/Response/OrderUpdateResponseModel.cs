namespace GoodHamburguer.API.Model.Response
{
    public class OrderUpdateResponseModel
    {
        public OrderResponseModel Old { get; set; }
        public OrderResponseModel New { get; set; }
    }
}
