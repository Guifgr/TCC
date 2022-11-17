﻿namespace TccUmc.Application.DTO.Professional;

public class ProfessionalGetDto
{
        public Guid Guid { get; set; }
        public string ProfessionalDoc { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
}