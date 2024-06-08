using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

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
        
        switch (value.Length)
        {
            case < 3:
                throw new ArgumentException("Name length requires minimum 3 characters.", nameof(value));
            case > 100:
                throw new ArgumentException("Name length requires maximum 100 characters.", nameof(value));
            default:
                Value = value;
                break;
        }
            
        Value = value;
    }

    public static implicit operator SurveyName(string value) => new SurveyName(value);

    public static implicit operator string(SurveyName value) => value.Value;

    public override string ToString() => Value;
}