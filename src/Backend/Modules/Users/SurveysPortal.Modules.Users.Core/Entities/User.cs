using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Core.Entities;

public sealed class User : IdentityUser<Guid>
{
    [ExcludeFromCodeCoverage]
    public User() {}
    public User
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
        Activate();
        DisplayName = displayName.IsNotEmpty()
            ? displayName
            : $"{firstName} {lastName}";
        SecurityStamp = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        EmailConfirmed = true;
    }

    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public bool IsActive { get; set; }
    public string DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
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

    public void Activate()
    {
        IsActive = true;
        Update();
    }

    public void Deactivate()
    {
        IsActive = false;
        Update();
    }
}