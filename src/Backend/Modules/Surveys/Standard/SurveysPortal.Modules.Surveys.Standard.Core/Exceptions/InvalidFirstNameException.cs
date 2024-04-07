using SurveysPortal.Modules.Users.Core.ValueObjects;
using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class InvalidFirstNameException : CustomException
{
    public InvalidFirstNameException() : base(null!) {}
    public InvalidFirstNameException(FirstName firstName) : base($"First name: '{firstName}' is invalid.")
    {
        LastName = firstName;
    }

    public FirstName LastName { get; }
}