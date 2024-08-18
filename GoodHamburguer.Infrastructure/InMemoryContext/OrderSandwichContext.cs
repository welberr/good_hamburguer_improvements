using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class OrderSandwichContext : DbContext
    {
        public OrderSandwichContext(DbContextOptions<OrderSandwichContext> options) : base(options)
        {
            
        }

        public DbSet<OrderSandwich> OrdersSandwich { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
