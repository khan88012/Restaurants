﻿
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantRepository
{
    public Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);

    Task<int> Create(Restaurant entity);

    Task Delete(Restaurant entity);

    Task SaveChanges();
}
