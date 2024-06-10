using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

public class SurveyName
{
    public string Value { get; }

    [ExcludeFromCodeCoverage]
    public SurveyName()
    {
    }

    public SurveyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Name of the survey cannot be empty.", nameof(value));
        }

        Value = value.Length switch
        {
            < 3 => throw new ArgumentException("Name length requires minimum 3 characters.", nameof(value)),
            > 100 => throw new ArgumentException("Name length requires maximum 100 characters.", nameof(value)),
            _ => value
        };

        Value = value;
    }

    public static implicit operator SurveyName(string value) => new (value);

    public static implicit operator string(SurveyName value) => value.Value;

    public override string ToString() => Value;
}