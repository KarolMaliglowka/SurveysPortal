using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Application.DTO;
using SurveysPortal.Modules.Users.Application.DTO.Extensions;
using SurveysPortal.Modules.Users.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class GetAllUsersHandler : IQueryHandler<GetAllUsers, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler()
    {
    }

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync(GetAllUsers query, CancellationToken cancellationToken = default)
    {
        var usersList = await _userRepository
            .GetAllUsers();
        return usersList
            .ToUsersListDto();
    }
}