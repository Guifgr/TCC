using System.ComponentModel.DataAnnotations;
using TccUmc.Application.DTO.Professional;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Procedures;

public class ProcedurePostDto
{
    [Required] public string Name { get; set; }
    public List<ProfessionalGetDto>? QualifieldProfessionals { get; set; }
    public double ProcedureMinutes { get; set; }
}