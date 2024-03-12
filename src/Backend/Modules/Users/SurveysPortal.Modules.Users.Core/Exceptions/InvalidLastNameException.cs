using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Core.Exceptions;

public class InvalidLastNameException : CustomException
{
    public InvalidLastNameException() : base(null!)
    {
    }

    public InvalidLastNameException(LastName lastName) : base($"Last name: '{lastName}' is invalid.")
    {
        LastName = lastName;
    }

    public LastName LastName { get; }
}