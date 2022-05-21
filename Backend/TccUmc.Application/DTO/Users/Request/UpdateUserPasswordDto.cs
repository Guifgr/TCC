using System.ComponentModel.DataAnnotations;

namespace TccUmc.Application.DTO.Users.Request;

public class UpdateUserPasswordDto
{
    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;
}