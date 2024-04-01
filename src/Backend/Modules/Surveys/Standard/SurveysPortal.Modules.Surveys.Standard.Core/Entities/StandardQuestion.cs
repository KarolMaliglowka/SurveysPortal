using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardQuestion
{
    private List<StandardSurveyQuestion> _standardSurveyQuestions = new();
    private List<string> _offeredAnswers = new();

    [ExcludeFromCodeCoverage]
    public StandardQuestion()
    {
    }

    public StandardQuestion(string text, bool isOfferedAnswers)
    {
        SetQuestion(text);
        IsOfferedAnswers = isOfferedAnswers;
        CreatedAt = DateTime.UtcNow;
    }

    [ExcludeFromCodeCoverage] public int Id { get; }
    public Guid UserId { get; set; }
    public string Text { get; private set; }
    public bool Required { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsOfferedAnswers { get; set; }
    public IReadOnlyCollection<string> OfferedAnswers => _offeredAnswers.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
    public IReadOnlyCollection<StandardSurveyQuestion> StandardSurveyQuestions => _standardSurveyQuestions.AsReadOnly();

    public void SetQuestion(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentNullException(nameof(text), "Question cannot be empty.");
        }

        switch (text.Length)
        {
            case < 10: throw new ArgumentException("Question cannot be shorter than 10 characters.");

            case > 1000: throw new ArgumentException("Question cannot be longer than 1000 characters.");
        }

        Text = text;
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
        _offeredAnswers = new List<string>();
    }
}