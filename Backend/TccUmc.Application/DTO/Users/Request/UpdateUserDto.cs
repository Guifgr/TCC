using System.ComponentModel.DataAnnotations;
using TccUmc.Domain.Exceptions;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.DTO.Users.Request;

public class UpdateUserDto
{
    public UpdateUserDto(string name, string cpf, AddressDto address, string cnpj = "")
    {
        if (!Validate.IsCpf(cpf))
        {
            throw new BadRequestException("Cpf invalido");
        }

        if (cnpj != string.Empty && !Validate.IsCnpj(cnpj))
        {
            throw new BadRequestException("Cnpj invalido");
        }
        
        Name = name;
        Cpf = cpf;
        Address = address;
        Cnpj = cnpj;
    }

    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;

    /// <example>551.799.550-09</example>
    [Required]
    [MaxLength(11)]
    [MinLength(11)]
    public string Cpf { get; set; } = string.Empty;

    [MaxLength(14)] [MinLength(14)] public string? Cnpj { get; set; } = string.Empty;
    [Required] public AddressDto Address { get; set; } = new AddressDto();
}