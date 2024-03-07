using SurveysPortal.Modules.Users.Core.DTO;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Users.Core.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}