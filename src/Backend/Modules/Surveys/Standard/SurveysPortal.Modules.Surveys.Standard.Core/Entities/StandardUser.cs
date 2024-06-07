using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardUser
{
    private List<StandardSurveyUser> _standardSurveyParticipants = new();
    
    [ExcludeFromCodeCoverage]
    public StandardUser() {}
    public StandardUser
    (
        Question question,
        LastName lastName,
        Username userName,
        Email email,
        string displayName
    )
    {
        SetFirstName(question);
        SetLastName(lastName);
        SetUsername(userName);
        SetEmail(email);
        DisplayName = displayName.IsNotEmpty()
            ? displayName
            : $"{question} {lastName}";
    }

    public Guid Id { get; set; }
    public Question Question { get; set; }
    public LastName LastName { get; set; }
    public string DisplayName { get; set; }
    public Username UserName { get; set; }
    public Email Email { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public IReadOnlyCollection<StandardSurveyUser> StandardSurveyParticipants =>
        _standardSurveyParticipants.AsReadOnly();
    
    private void Update() => UpdatedAt = DateTime.UtcNow;

    private void SetUsername(Username username)
    {
        UserName = username;
        Update();
    }

    public string GetFullName() => Question + " " + LastName;

    private void SetEmail(Email email)
    {
        Email = email;
        Update();
    }

    private void SetFirstName(Question question)
    {
        Question = question;
        Update();
    }

    private void SetLastName(LastName lastName)
    {
        LastName = lastName;
        Update();
    }
}