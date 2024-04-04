using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

//public record UserSession(string? Id, string? Name, string? Email, string? Role);

public class UserSession()
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}