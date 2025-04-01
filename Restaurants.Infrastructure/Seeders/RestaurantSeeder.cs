

using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync()) //check whether we can connect to db
        {
            if (!dbContext.Restaurants.Any()) //no data in the table
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant
            {

                Name = "Gourmet Palace",
                Description = "A fine dining experience with exquisite meals.",
                Category = "Fine Dining",
                HasDelivery = true,
                ContactEmail = "contact@gourmetpalace.com",
                ContactNumber = "123-456-7890",
                Address = new Address
                {
                    City = "New York",
                    Street = "5th Avenue",
                    PostalCode = "10001"
                },
                Dishes = new List<Dish>
                {
                    new Dish {  Name = "Grilled Salmon", Description = "Freshly grilled salmon with lemon butter sauce.", Price = 25.99M, RestaurantId = 1 },
                    new Dish {  Name = "Steak", Description = "Juicy grilled steak with garlic butter.", Price = 30.50M, RestaurantId = 1 }
                }
            },
            new Restaurant
            {

                Name = "Fast Bites",
                Description = "Quick and delicious fast food.",
                Category = "Fast Food",
                HasDelivery = true,
                ContactEmail = "support@fastbites.com",
                ContactNumber = "987-654-3210",
                Address = new Address
                {
                    City = "Los Angeles",
                    Street = "Sunset Blvd",
                    PostalCode = "90028"
                },
                Dishes = new List<Dish>
                {
                    new Dish {  Name = "Cheeseburger", Description = "Classic cheeseburger with fresh toppings.", Price = 5.99M, RestaurantId = 2 },
                    new Dish {  Name = "Fries", Description = "Crispy golden fries.", Price = 2.99M, RestaurantId = 2 }
                }
            }
        };

        return restaurants;

    }
}
