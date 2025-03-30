
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantDbContext : DbContext
    {
        internal DbSet<Restaurant> Restaurants { get; set; }    

        internal DbSet<Dish> dishes { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NEUDESICB1KJQL3\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;"); //added TrustServerCertificate to Bypasses SSL/TLS certificate validation when encrypting the connection. Useful when SQL Server is using a self-signed or untrusted certificate.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);  //address is owned by Restaurant table so we dont need to create seperate table the address columns are present in the Restaurant table

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
