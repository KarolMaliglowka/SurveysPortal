using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

public sealed record Username
{
    public string Value { get; }

    [ExcludeFromCodeCoverage]
    public Username()
    {
    }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 3)
        {
            throw new InvalidFullNameException(value);
        }
            
        Value = value;
    }

    public static implicit operator Username(string value) => new (value);

    public static implicit operator string(Username value) => value.Value;

    public override string ToString() => Value;
}