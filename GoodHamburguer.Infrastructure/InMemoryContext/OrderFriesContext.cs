using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class OrderFriesContext : DbContext
    {
        public OrderFriesContext(DbContextOptions<OrderFriesContext> options) : base(options)
        {
            
        }

        public DbSet<OrderFries> OrdersFries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
