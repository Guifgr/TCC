using System.ComponentModel.DataAnnotations;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Professional;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Consult;

public class ConsultGetDto
{
    public Guid Guid { get; set; }   
    public ProfessionalGetDto Professional { get; set; }
    public DateTime ConsultStart { get; set; }
    public DateTime ConsultEnd { get; set; }
    public string Observations { get; set; } = string.Empty;
    public ConsultStatus Status { get; set; }
    public ProcedureGetDto Procedure { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}