using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data.InMemoryContext
{
    public class FriesContext : DbContext
    {
        public DbSet<Fries> Fries { get; set; }
        
        public FriesContext
        (
            DbContextOptions<FriesContext> options

        ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fries>().HasData(
                new Fries
                {
                    Id = 1,
                    Name = "Fries",
                    Price = 2.00m
                }
            );
        }
    }
}
