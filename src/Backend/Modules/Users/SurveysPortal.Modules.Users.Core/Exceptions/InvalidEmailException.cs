namespace SurveysPortal.Modules.Users.Core.Exceptions;


public sealed class InvalidEmailException(string email) : CustomException($"Email: '{email}' is invalid.")
{
    public string Email { get; } = email;
}