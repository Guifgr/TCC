using System.ComponentModel.DataAnnotations;
using TccUmc.Application.DTO.Professional;
using TccUmc.Domain.Enums;

namespace TccUmc.Application.DTO.Procedures;

public class ProcedureGetDto
{
    [Required] public Guid Guid { get; set; }
    [Required] public string Name { get; set; }
    public List<ProfessionalGetDto>? QualifieldProfessionals { get; set; }
    public double ProcedureMinutes { get; set; }
}