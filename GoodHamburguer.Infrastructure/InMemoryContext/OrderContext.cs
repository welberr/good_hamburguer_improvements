using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        
        public OrderContext
        (
            DbContextOptions<OrderContext> options

        ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
