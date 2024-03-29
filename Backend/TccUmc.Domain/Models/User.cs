﻿#nullable enable
using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class User : UserBaseModel
{
    public string Cnpj { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public Role Role { get; set; }
    public bool IsActive { get; set; }
}