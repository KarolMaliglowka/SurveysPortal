using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public sealed class InvalidFullNameException : CustomException
{
    public InvalidFullNameException() : base(null!) {}
    public InvalidFullNameException(string fullName) : base($"Full name: '{fullName}' is invalid.")
    {
        FullName = fullName;
    }

    public string FullName { get; }
}