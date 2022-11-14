using System.ComponentModel.DataAnnotations;
using TccUmc.Domain.Enums;

namespace TccUmc.Application.DTO.Procedures;

public class ClinicProcedureDto
{
    [Required] public Guid Guid { get; set; }
    [Required] public string Name { get; set; }
    public List<ProfessionalDto>? QualifieldProfessionals { get; set; }
    public double TimeSpent { get; set; }
    public TimeType TimeType { get; set; }
}