using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardQuestion
{
    private readonly List<StandardSurveyQuestion> _standardSurveyQuestions = [];
    private List<string> _offeredAnswers = [];

    [ExcludeFromCodeCoverage]
    public StandardQuestion()
    {
    }

    public StandardQuestion(Question text, bool required)
    {
        SetQuestion(text);
        Required = required;
        CreatedAt = DateTime.UtcNow;
    }

    [ExcludeFromCodeCoverage] public int Id { get; set; }

    [ExcludeFromCodeCoverage] public Guid UserId { get; set; }
    public Question Question { get; set; }
    public bool Required { get; set; }
    public bool IsDeleted { get; private set; }
    public bool IsOfferedAnswers { get; set; }
    public IReadOnlyCollection<string> OfferedAnswers => _offeredAnswers.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
    public IReadOnlyCollection<StandardSurveyQuestion> StandardSurveyQuestions => _standardSurveyQuestions.AsReadOnly();

    public void SetQuestion(Question question)
    {
        Question = question;
        UpdateAt();
    }

    private void UpdateAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAsDeleted()
    {
        IsDeleted = true;
        UpdateAt();
    }

    public void SetAsNotRequired()
    {
        Required = false;
        UpdateAt();
    }

    public void SetRequired()
    {
        Required = true;
        UpdateAt();
    }

    public void SetOfferedAnswers(List<string> offeredAnswers)
    {
        if (offeredAnswers == null || offeredAnswers.Count == 0)
        {
            throw new ArgumentNullException(nameof(offeredAnswers), "List cannot be empty.");
        }

        var correctOfferedAnswers = offeredAnswers.Where(oa => !string.IsNullOrWhiteSpace(oa)).ToList();
        _offeredAnswers = correctOfferedAnswers;
    }

    public void ClearOfferedAnswers()
    {
        _offeredAnswers = [];
    }
}