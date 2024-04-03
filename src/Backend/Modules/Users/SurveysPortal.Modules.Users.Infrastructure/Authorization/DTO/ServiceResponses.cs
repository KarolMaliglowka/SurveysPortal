namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

public class ServiceResponses
{
    public record GeneralResponse(bool Flag, string Message);

    public record LoginResponse(bool Flag, string Token, string Message);
}