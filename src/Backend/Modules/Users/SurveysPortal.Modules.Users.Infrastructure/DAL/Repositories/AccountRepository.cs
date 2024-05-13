using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;
using SurveysPortal.Modules.Users.Infrastructure.Authorization.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;

namespace SurveysPortal.Modules.Users.Infrastructure.DAL.Repositories;

[Injectable(ServiceLifetime.Scoped)]
public class AccountRepository : IUserAccount
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public AccountRepository(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }

    public AccountRepository()
    {
    }

    public async Task<ServiceResponses.GeneralResponse> CreateAccount(UserDto userDto)
    {
        if (userDto is null) return new ServiceResponses.GeneralResponse();
        
            //(false, "Model is empty");
        var newUser = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PasswordHash = userDto.Password,
            UserName = userDto.Email
        };
        var user = await _userManager.FindByEmailAsync(newUser.Email);
        if (user is not null) return new ServiceResponses.GeneralResponse
        {
            Flag = false,
            Message = "User registered already"
        };

        var createUser = await _userManager.CreateAsync(newUser!, userDto.Password);
        if (!createUser.Succeeded)
            return new ServiceResponses.GeneralResponse
            {
                Flag = false,
                Message = "Error occured.. please try again"
            };

        //Assign Default Role : Admin to first registrar; rest is user
        var checkAdmin = await _roleManager.FindByNameAsync("Admin");
        if (checkAdmin is null)
        {
            await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await _userManager.AddToRoleAsync(newUser, "Admin");
            return new ServiceResponses.GeneralResponse
            {
                Flag = false,
                Message = "Account Created"
            };
            //(true, "Account Created");
        }
        else
        {
            var checkUser = await _roleManager.FindByNameAsync("User");
            if (checkUser is null)
                await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });

            await _userManager.AddToRoleAsync(newUser, "User");
            return new ServiceResponses.GeneralResponse
            {
                Flag = false,
                Message = "Account Created"
            };
            //(true, "Account Created");
        }
    }

    public async Task<ServiceResponses.LoginResponse> LoginAccount(LoginDto? loginDto)
    {
        if (loginDto == null)
            return new ServiceResponses.LoginResponse
            {
                Flag = false,
                Token = null!,
                Message = "Login container is empty"
            };
                //(false, null!, "Login container is empty");

        var getUser = await _userManager.FindByEmailAsync(loginDto.Email);
        if (getUser is null)
            return new ServiceResponses.LoginResponse
            {
                Flag = false,
                Token = null!,
                Message = "User not found"
            };
                //(false, null!, "User not found");

        bool checkUserPasswords = await _userManager.CheckPasswordAsync(getUser, loginDto.Password);
        if (!checkUserPasswords)
            return new ServiceResponses.LoginResponse
            {
                Flag = false,
                Token = null!,
                Message = "Invalid email/password"
            };
//                (false, null!, "Invalid email/password");

        var getUserRole = await _userManager.GetRolesAsync(getUser);
        var userSession = new UserSession()
        {
            Id = getUser.Id.ToString(),
            Name = getUser.FirstName,
            Email = getUser.Email,
            Role = getUserRole.First()
        };
            //( getUser.Id.ToString(), getUser.FirstName, getUser.Email, getUserRole.First());
        string token = GenerateToken(userSession);
        return new ServiceResponses.LoginResponse
        {
            Flag = false,
            Token = null!,
            Message = "Login completed"
        };
          //  (true, token!, "Login completed");
    }

    private string GenerateToken(UserSession user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSetting:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}