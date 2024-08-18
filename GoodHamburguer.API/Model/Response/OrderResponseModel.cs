namespace GoodHamburguer.API.Model.Response
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public SandwichResponseModel? Sandwich { get; set; }
        public FriesResponseModel? Fries { get; set; }
        public DrinkResponseModel? Drink { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal FinalAmount { get; set; } = decimal.Zero;
    }
}
