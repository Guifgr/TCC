using System.ComponentModel.DataAnnotations;

namespace TccUmc.Application.DTO.Users.Request;

public class UpdateUserPasswordDto
{
    [EmailAddress] [Required] public string Email { get; set; } = string.Empty;

    [Required] public string Token { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string NewPassword { get; set; } = string.Empty;
}