#nullable enable
using TccBackendUmc.Domain.Enums;

namespace TccBackendUmc.Domain.Models;

public class User : UserBaseModel
{
    public string? Cnpj { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
}