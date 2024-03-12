namespace SurveysPortal.Modules.Users.Core.Exceptions;


public sealed class InvalidEmailException : CustomException
{
    public InvalidEmailException() : base(null!) {}
    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }

    public string Email { get; }
}