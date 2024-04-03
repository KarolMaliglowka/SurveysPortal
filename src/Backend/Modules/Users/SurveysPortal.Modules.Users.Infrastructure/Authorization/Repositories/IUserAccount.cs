using SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.Repositories;

public interface IUserAccount
{
    Task<ServiceResponses.GeneralResponse> CreateAccount(UserDto userDto);
    Task<ServiceResponses.LoginResponse> LoginAccount(LoginDto loginDto);
}