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
        FirstName firstName,
        LastName lastName,
        Username userName,
        Email email,
        string displayName
    )
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetUsername(userName);
        SetEmail(email);
        DisplayName = displayName.IsNotEmpty()
            ? displayName
            : $"{firstName} {lastName}";
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public FirstName FirstName { get; set; }
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

    public string GetFullName() => FirstName + " " + LastName;

    private void SetEmail(Email email)
    {
        Email = email;
        Update();
    }

    private void SetFirstName(FirstName firstName)
    {
        FirstName = firstName;
        Update();
    }

    private void SetLastName(LastName lastName)
    {
        LastName = lastName;
        Update();
    }
}