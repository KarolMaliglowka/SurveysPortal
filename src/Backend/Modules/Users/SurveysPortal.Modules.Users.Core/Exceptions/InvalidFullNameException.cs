namespace SurveysPortal.Modules.Users.Core.Exceptions;


public sealed class InvalidFullNameException(string fullName) : CustomException($"Full name: '{fullName}' is invalid.")
{
    public string FullName { get; } = fullName;
}