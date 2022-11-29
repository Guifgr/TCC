using System.ComponentModel.DataAnnotations;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Professional;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Consult;

public class ConsultGetDto
{
    public Guid Guid { get; set; }
    public UserDTO User { get; set; }
    public ProfessionalGetDto Professional { get; set; }
    public DateTime ConsultStart { get; set; }
    public DateTime ConsultEnd { get; set; }
    public string Observations { get; set; } = string.Empty;
    public ConsultStatus Status { get; set; }
    public ProcedureGetDto Procedure { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public ClinicDto Clinic { get; set; }
}

public class ClinicDto
{
    public string? Cnpj { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Whatsapp { get; set; } = string.Empty;
}

public class UserDTO
{
    public Guid Guid { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
}