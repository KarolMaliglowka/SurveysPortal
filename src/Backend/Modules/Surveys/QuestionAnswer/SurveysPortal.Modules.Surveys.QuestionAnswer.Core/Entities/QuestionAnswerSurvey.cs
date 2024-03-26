namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerSurvey
{
    protected QuestionAnswerSurvey() { }

    public QuestionAnswerSurvey
    (
        string name,
        string description,
        string introduction
    )
    {
        SetName(name);
        SetDescription(description);
        SetIntroduction(introduction);
        CreatedAt = DateTime.UtcNow;
    }
    
    
    public int Id { get; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; private set; }
    public string Introduction { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name of the survey cannot be empty.", nameof(name));
        }

        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetIntroduction(string introduction)
    {
        Introduction = introduction;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void MarkAsDeleted() => IsDeleted = true;
}