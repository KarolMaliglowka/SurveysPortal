using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Core.Exceptions;
using SurveysPortal.Modules.Users.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Users.Application.Commands.Handlers;
[Injectable(ServiceLifetime.Scoped)]
public class ActivateUserHandler : ICommandHandler<ActivateUser>
{
    private readonly IUserRepository _userRepository;

    public ActivateUserHandler()
    {
    }

    public ActivateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(ActivateUser command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(command.UserId);
        if (user is null)
        {
            throw new UserNotFoundException(command.UserId);
        }

        user.Activate();
        await _userRepository.Update(user);
    }
}