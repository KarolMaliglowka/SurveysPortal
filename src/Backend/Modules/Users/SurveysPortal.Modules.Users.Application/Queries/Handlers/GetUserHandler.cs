using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Application.DTO;
using SurveysPortal.Modules.Users.Application.DTO.Extensions;
using SurveysPortal.Modules.Users.Core.Exceptions;
using SurveysPortal.Modules.Users.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler()
    {
    }

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> HandleAsync(GetUser query, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetAsync(query.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(query.UserId);
        }

        return user.ToUserDto();
    }
}