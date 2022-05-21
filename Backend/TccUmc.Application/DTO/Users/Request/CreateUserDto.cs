using System.ComponentModel.DataAnnotations;

namespace TccUmc.Application.DTO.Users.Request;

public class CreateUserDto
{
    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [MaxLength(11)]
    public string Cpf { get; set; } = string.Empty;
    [MaxLength(14)]
    public string? Cnpj { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public AddressDto Address { get; set; } = new AddressDto();
}