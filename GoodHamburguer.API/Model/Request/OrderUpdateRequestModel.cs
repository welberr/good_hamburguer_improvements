namespace GoodHamburguer.API.Model.Request
{
    public class OrderUpdateRequestModel
    {
        public int Id { get; set; }
        public SandwichRequestModel? Sandwich { get; set; }
        public FriesRequestModel? Fries { get; set; }
        public DrinkRequestModel? Drink { get; set; }
    }
}
