using System.ComponentModel.DataAnnotations;
using TccUmc.Domain.Exceptions;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.DTO.Users.Request;

public class UpdateUserDto
{
    public UpdateUserDto(string name, AddressDto address, string cnpj = "")
    {
        if (cnpj != string.Empty && !Validate.IsCnpj(cnpj)) throw new BadRequestException("Cnpj invalido");

        Name = name;
        Address = address;
        Cnpj = cnpj;
    }

    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [MaxLength(14)] [MinLength(14)] public string? Cnpj { get; set; } = string.Empty;
    [Required] public AddressDto Address { get; set; } = new();
}