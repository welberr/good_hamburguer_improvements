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

        public bool HasOrderId()
        {
            return this.Id > 0;
        }

        public bool HasSandwich()
        {
            return this.Sandwich is Sandwich && this.Sandwich.Id > 0;
        }

        public bool HasFries()
        {
            return this.Fries is Fries && this.Fries.Id > 0;
        }

        public bool HasDrink()
        {
            return this.Drink is Drink && this.Drink.Id > 0;
        }
    }
}
