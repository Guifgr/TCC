using System.ComponentModel.DataAnnotations;

namespace TccBackendUmc.Application.DTO.Login.Request;

public class FirstLoginRequestDto
{
    public string Cpf { get; set; } = string.Empty;
    [Required] public string Cnpj { get; set; } = string.Empty;
    [Required] public string CodigoEmpresa { get; set; } = string.Empty;
}