using SurveysPortal.Modules.Users.Core.DTO;
using SurveysPortal.Modules.Users.Core.DTO.Extensions;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Core.Queries.Handlers;

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

    public async Task<IEnumerable<UserDto>?> HandleAsync(GetAllUsers query,
        CancellationToken cancellationToken = default)
    {
        var usersList = await _userRepository.GetAllUsers();
        return usersList.ToUsersListDto();
    }
}