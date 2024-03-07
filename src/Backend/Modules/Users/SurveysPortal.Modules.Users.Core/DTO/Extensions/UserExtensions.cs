using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Users.Core.DTO.Extensions;

public static class UserExtensions
{
    public static UserDto? ToUserDto(this User? user)
    {
        if (user != null)
        {
            return new UserDto
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };
        }
        
        return null;
    }

    public static IEnumerable<UserDto>? ToUsersListDto(this IEnumerable<User> users)
    {
        return users?.Select
        (
            x => new UserDto
            {
                UserId = x.Id,
                Username = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DisplayName = x.DisplayName,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            }
        ).ToList();
    }
}