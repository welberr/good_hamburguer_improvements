using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class OrderDrinkContext : DbContext
    {
        public OrderDrinkContext(DbContextOptions<OrderDrinkContext> options) : base(options)
        {
            
        }

        public DbSet<OrderDrink> OrdersDrink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
