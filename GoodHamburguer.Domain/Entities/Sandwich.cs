namespace GoodHamburguer.Domain.Entities
{
    public class Sandwich
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
    }
}
