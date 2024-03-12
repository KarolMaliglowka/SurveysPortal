using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Core.Exceptions;

public class InvalidFirstNameException : CustomException
{
    public InvalidFirstNameException() : base(null!) {}
    public InvalidFirstNameException(FirstName firstName) : base($"First name: '{firstName}' is invalid.")
    {
        LastName = firstName;
    }

    public FirstName LastName { get; }
}