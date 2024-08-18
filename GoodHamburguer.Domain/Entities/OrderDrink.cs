namespace GoodHamburguer.Domain.Entities
{
    public class OrderDrink
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DrinkId { get; set; }
    }
}
