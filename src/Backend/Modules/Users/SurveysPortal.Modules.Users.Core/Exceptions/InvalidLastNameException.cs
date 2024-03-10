using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Core.Exceptions;

public class InvalidLastNameException (LastName lastName) : CustomException($"Last name: '{lastName}' is invalid.")
{
    public LastName LastName { get; } = lastName;
}