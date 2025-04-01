

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public  class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurentCommand, int>
{
    public async Task<int> Handle(CreateRestaurentCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a restaurant");
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantRepository.Create(restaurant);
        return id;
    }
}
