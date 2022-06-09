using System.ComponentModel.DataAnnotations;
using TccUmc.Domain.Exceptions;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.DTO.Users.Request;

public class CreateUserDto
{
    public CreateUserDto(string email, string cpf, string password)
    {
        if (!Validate.IsCpf(cpf))
        {
            throw new BadRequestException("Cpf invalido");
        }

        Email = email;
        Cpf = cpf;
        Password = password;
    }
    
    [Required] public string Cpf { get; set; } = string.Empty;
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}