namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

public abstract class ServiceResponses
{
    public abstract record GeneralResponse(bool Flag, string Message);

    public abstract record LoginResponse(bool Flag, string Token, string Message);
}