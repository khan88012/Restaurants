
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Restaurants.Application.Users;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtension).Assembly; //we need the Application Assembly refrence for automapper to work
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly); 
        services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();//we need to inject this as well as we are making use of httpcontext in the usercontext class
    }
}
