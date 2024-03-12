using SurveysPortal.Modules.Users.Core.Exceptions;

namespace SurveysPortal.Modules.Users.Core.ValueObjects;

public record FirstName
{
    public string Value { get; }

    public FirstName()
    {
    }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 2)
        {
            throw new InvalidFirstNameException(value);
        }
            
        Value = value;
    }

    public static implicit operator FirstName(string value) => new FirstName(value);

    public static implicit operator string(FirstName value) => value.Value;

    public override string ToString() => Value;
}