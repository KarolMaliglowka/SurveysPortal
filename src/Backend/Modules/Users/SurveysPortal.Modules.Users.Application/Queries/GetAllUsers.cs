using SurveysPortal.Modules.Users.Application.DTO;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Application.Queries;

public class GetAllUsers : IQuery<IEnumerable<UserDto>>;