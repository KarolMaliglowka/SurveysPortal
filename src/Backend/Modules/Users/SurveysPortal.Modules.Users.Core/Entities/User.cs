using Microsoft.AspNetCore.Identity;

namespace SurveysPortal.Modules.Users.Core.Entities;

public sealed class User : IdentityUser<Guid>
{
    public User() {}
    public User
    (
        string firstName,
        string lastName,
        string userName,
        string email,
        string displayName
    )
    {
        FirstName = firstName;
        LastName = lastName;
        SecurityStamp = Guid.NewGuid().ToString();
        SetFirstName(firstName);
        SetLastName(lastName);
        SetUsername(userName);
        SetEmail(email);
        Activate();
        CreatedAt = DateTime.UtcNow;
        EmailConfirmed = true;
        DisplayName = displayName.IsNotEmpty()
            ? displayName
            : $"{firstName} {lastName}";
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public string DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private void Update() => UpdatedAt = DateTime.UtcNow;

    private void SetUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException(nameof(username), "User name cannot be empty.");
        }

        UserName = username;
        Update();
    }

    public string GetFulName() => FirstName + " " + LastName;

    private void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException(nameof(email), "Email cannot be empty.");
        }

        if (!email.IsEmail())
        {
            throw new ArgumentException("Email is not valid.", nameof(email));
        }

        Email = email;
        Update();
    }

    private void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException(nameof(firstName), "First name cannot be empty.");
        }

        FirstName = firstName;
        Update();
    }

    private void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException(nameof(lastName), "Last name cannot be empty.");
        }

        LastName = lastName;
        Update();
    }

    private void Activate()
    {
        IsActive = true;
        Update();
    }

    private void Deactivate()
    {
        IsActive = false;
        Update();
    }
}