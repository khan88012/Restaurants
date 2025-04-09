

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Commands.AssignUserRoleCommand;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning role {RoleName} to user {UserEmail}", request.RoleName, request.UserEmail);

        var user = await userManager.FindByEmailAsync(request.UserEmail);
        if (user == null)
        {
            logger.LogWarning("User with email {UserEmail} not found", request.UserEmail);
            return;
        }
        var role = await roleManager.FindByNameAsync(request.RoleName);
        if (role == null)
        {
            logger.LogWarning("Role {RoleName} not found", request.RoleName);
            return;
        }

        await userManager.AddToRoleAsync(user, request.RoleName);
    }

}

