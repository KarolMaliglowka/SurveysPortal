using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Core.Exceptions;
using SurveysPortal.Modules.Users.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Users.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class DeactivateUserHandler : ICommandHandler<DeactivateUser>
{
    private readonly IUserRepository _userRepository;

    public DeactivateUserHandler()
    {
    }

    public DeactivateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(DeactivateUser command, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetAsync(command.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(command.UserId);
        }

        user.Deactivate();
        await _userRepository.Update(user);
    }
}