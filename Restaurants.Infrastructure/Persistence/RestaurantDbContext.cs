
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : IdentityDbContext<User>(options)
    {
        internal DbSet<Restaurant> Restaurants { get; set; }    

        internal DbSet<Dish> dishes { get; set; }   

       

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
