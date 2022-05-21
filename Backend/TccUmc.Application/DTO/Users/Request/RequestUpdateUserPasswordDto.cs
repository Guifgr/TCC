using System.ComponentModel.DataAnnotations;

namespace TccUmc.Application.DTO.Users.Request;

public class RequestUpdateUserPasswordDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}