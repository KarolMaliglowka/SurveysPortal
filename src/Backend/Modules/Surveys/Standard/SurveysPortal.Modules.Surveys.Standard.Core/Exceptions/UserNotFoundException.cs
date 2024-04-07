using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class UserNotFoundException : CustomException
{
    public Guid UserId { get; }

    public UserNotFoundException() : base(null!) {}
    
    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}