using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

public record Question
{
    public string StandardQuestion { get; }

    [ExcludeFromCodeCoverage]
    public Question()
    {
    }

    /// <summary>
    ///  First name value object   
    /// </summary>
    /// <param name="question">users first name </param>
    /// <returns>valid FirstName</returns>
    /// <exception cref="InvalidFirstNameException"> firstname can't be null or whitespace and
    /// must be grater than 2 chars and lesser than 30 chars</exception>
    public Question(string question)
    {
        if (string.IsNullOrWhiteSpace(question))
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be empty.");
        }

        switch (question.Length)
        {
            case > 1000:
                throw new ArgumentException("Question cannot be longer than 1000 characters.");
            case < 10:
                throw new ArgumentException("Question cannot be shorter than 10 characters.");
            default:
                StandardQuestion = question;
                break;
        }
            
        StandardQuestion = question;
    }

    public static implicit operator Question(string value) => new(value);

    public static implicit operator string(Question value) => value.StandardQuestion;

    public override string ToString() => StandardQuestion;
}