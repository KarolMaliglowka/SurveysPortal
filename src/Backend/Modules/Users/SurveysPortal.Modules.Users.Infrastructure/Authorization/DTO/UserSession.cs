namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

public record UserSession(string? Id, string? Name, string? Email, string? Role);