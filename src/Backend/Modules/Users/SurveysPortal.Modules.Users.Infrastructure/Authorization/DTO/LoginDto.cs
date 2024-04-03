using System.ComponentModel.DataAnnotations;

namespace SurveysPortal.Modules.Users.Infrastructure.Authorization.DTO;

public class LoginDto
{
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}