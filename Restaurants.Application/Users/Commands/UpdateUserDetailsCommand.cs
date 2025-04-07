

using MediatR;

namespace Restaurants.Application.Users.Commands;

public class UpdateUserDetailsCommand : IRequest<bool>
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
