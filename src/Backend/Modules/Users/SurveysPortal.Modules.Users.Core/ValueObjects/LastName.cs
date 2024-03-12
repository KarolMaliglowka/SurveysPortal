using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Users.Core.Exceptions;

namespace SurveysPortal.Modules.Users.Core.ValueObjects;

public class LastName
{
    public string Value { get; }

    public LastName()
    {
    }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 2)
        {
            throw new InvalidLastNameException(value);
        }
            
        Value = value;
    }

    public static implicit operator LastName(string value) => new LastName(value);

    public static implicit operator string(LastName value) => value.Value;

    public override string ToString() => Value;
}