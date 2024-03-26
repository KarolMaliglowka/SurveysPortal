using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerAnswer
{
    private const string NotRequired = "Question was not required.";
        
    [ExcludeFromCodeCoverage]
    protected QuestionAnswerAnswer() { }

    public QuestionAnswerAnswer(QuestionAnswerSurveyUser questionAnswerSurveyUser, QuestionAnswerQuestion questionAnswerQuestion)
    {
        QuestionAnswerSurveyUser = questionAnswerSurveyUser ??
                                   throw new ArgumentNullException(nameof(questionAnswerSurveyUser),
                                       "Survey participant cannot be null.");
        QuestionAnswerQuestion = questionAnswerQuestion ??
                                 throw new ArgumentNullException(nameof(questionAnswerQuestion),
                                     "Question cannot be null.");
    }
    
    
    [ExcludeFromCodeCoverage] 
    public int Id { get; }
    public Guid UserId { get; set; }
    public int AnswerQuestionSurveyUserId { get; set; }
    public QuestionAnswerSurveyUser QuestionAnswerSurveyUser { get; }
    public QuestionAnswerQuestion QuestionAnswerQuestion { get; }
    public string Answer { get; private set; }
    public DateTime AnsweredAt { get; private set; }
}