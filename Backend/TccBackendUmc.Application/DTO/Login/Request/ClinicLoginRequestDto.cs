using System.ComponentModel.DataAnnotations;

namespace TccBackendUmc.Application.DTO.Login.Request;

public class ClincLoginRequestDto
{
    [Required] public string Cnpj { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}