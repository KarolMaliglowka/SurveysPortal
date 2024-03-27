namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Exceptions;

public class NotFoundOfferedAnswerException : Exception
{
    public NotFoundOfferedAnswerException()
    {
    }

    public NotFoundOfferedAnswerException(string message) : base(message)
    {
    }

    public NotFoundOfferedAnswerException(string message, Exception innerException) : base(message, innerException)
    {
    }
}