using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Users.Core.Exceptions;

namespace SurveysPortal.Modules.Users.Core.ValueObjects;

public record FirstName
{
    public string Value { get; }

    [ExcludeFromCodeCoverage]
    public FirstName()
    {
    }

    /// <summary>
    ///  First name value object   
    /// </summary>
    /// <param name="firstName">users first name </param>
    /// <returns>valid FirstName</returns>
    /// <exception cref="InvalidFirstNameException"> firstname can't be null or whitespace and
    /// must be grater than 2 chars and lesser than 30 chars</exception>
    public FirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length is > 30 or < 2)
        {
            throw new InvalidFirstNameException(firstName);
        }
            
        Value = firstName;
    }

    public static implicit operator FirstName(string value) => new FirstName(value);

    public static implicit operator string(FirstName value) => value.Value;

    public override string ToString() => Value;
}