using SurveysPortal.Modules.Users.Core.Repositories;

namespace SurveysPortal.Modules.Users.Core.Exceptions;

public class UserNotFoundException : SurveysPortalException
{
    public Guid UserId { get; }

    public UserNotFoundException() : base(null!) {}
    
    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}