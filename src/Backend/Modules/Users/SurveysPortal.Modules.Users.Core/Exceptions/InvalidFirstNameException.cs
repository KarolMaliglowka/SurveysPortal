using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Core.Exceptions;

public class InvalidFirstNameException (FirstName firstName) : CustomException($"First name: '{firstName}' is invalid.")
{
    public FirstName LastName { get; } = firstName;
}