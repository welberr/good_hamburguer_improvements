namespace GoodHamburguer.API.Model.Request
{
    public class OrderRequestModel
    {
        public SandwichRequestModel? Sandwich { get; set; }
        public FriesRequestModel? Fries { get; set; }
        public DrinkRequestModel? Drink { get; set; }
    }
}
