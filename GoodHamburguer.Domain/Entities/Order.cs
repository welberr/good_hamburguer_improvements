namespace GoodHamburguer.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Sandwich? Sandwich { get; set; }
        public Fries? Fries { get; set; }
        public Drink? Drink { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal FinalAmount { get; set; } = decimal.Zero;
        public bool Active { get; set; } = true;
    }
}
