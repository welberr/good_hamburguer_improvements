using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class DrinkContext : DbContext
    {
        public DbSet<Drink> Drink { get; set; }
        
        public DrinkContext
        (
            DbContextOptions<DrinkContext> options

        ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 1,
                    Name = "Soft drink",
                    Price = 2.50m
                }
            );
        }
    }
}
