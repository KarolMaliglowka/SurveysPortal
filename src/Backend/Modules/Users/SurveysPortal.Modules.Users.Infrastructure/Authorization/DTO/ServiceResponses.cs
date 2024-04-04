namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

public abstract class ServiceResponses
{
    //public record GeneralResponse(bool Flag, string Message);

    public class GeneralResponse()
    {
        public bool Flag { get; set; }
        public string Message { get; set; }
    }

    //public record LoginResponse(bool Flag, string Token, string Message);

    public class LoginResponse()
    {
        public bool Flag { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }

}