﻿using System.ComponentModel.DataAnnotations;

namespace TccBackendUmc.Application.DTO.Request;

public class LoginRequestDto
{
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}