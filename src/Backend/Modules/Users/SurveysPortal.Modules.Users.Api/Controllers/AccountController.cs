using Microsoft.AspNetCore.Mvc;
using SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;
using SurveysPortal.Modules.Users.Infrastructure.Authorization.Repositories;

namespace SurveysPortal.Modules.Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IUserAccount userAccount) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        var response = await userAccount.CreateAccount(userDto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var response = await userAccount.LoginAccount(loginDto);
        return Ok(response);
    }
}