using System.ComponentModel.DataAnnotations;

namespace TccBackendUmc.Application.DTO.Request;

public class FirstLoginCreatePasswordDto
{
    [Required] public string Password { get; set; } = string.Empty;
    [Required] public string PasswordRepeated { get; set; } = string.Empty;
}