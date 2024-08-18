using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class SandwichContext : DbContext
    {
        public DbSet<Sandwich> Sandwiches { get; set; }
        
        public SandwichContext
        (
            DbContextOptions<SandwichContext> options

        ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sandwich>().HasData(
                new Sandwich
                {
                    Id = 1,
                    Name = "X Burger",
                    Price = 5.00m
                },
                new Sandwich
                {
                    Id = 2,
                    Name = "X Egg",
                    Price = 4.50m
                },
                new Sandwich
                {
                    Id = 3,
                    Name = "X Bacon",
                    Price = 7.00m
                }
            );
        }
    }
}
