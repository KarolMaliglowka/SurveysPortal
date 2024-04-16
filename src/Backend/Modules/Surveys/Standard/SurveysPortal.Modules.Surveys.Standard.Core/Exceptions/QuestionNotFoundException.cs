using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class QuestionNotFoundException : CustomException
{
    public int QuestionId { get; }

    public QuestionNotFoundException() : base(null!) {}
    
    public QuestionNotFoundException(int questionId) : base($"Question with ID: '{questionId}' was not found.")
    {
        QuestionId = questionId;
    }
}