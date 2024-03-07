using SurveysPortal.Modules.Users.Core.DTO;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Core.Queries;

public class GetAllUsers : IQuery<IEnumerable<UserDto>>;