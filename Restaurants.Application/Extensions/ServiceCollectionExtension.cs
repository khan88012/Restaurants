
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtension).Assembly; //we need the Application Assembly refrence for automapper to work
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddAutoMapper(applicationAssembly); 
        services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();    
    }
}
