using System.ComponentModel.DataAnnotations;

namespace TccUmc.Application.DTO.Request;

public class LoginRequestDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}