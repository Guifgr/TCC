using System.ComponentModel.DataAnnotations;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Procedures;

public class ClinicProcedureCreateDto
{
    [Required] public string Name { get; set; }
    public List<ProfessionalDto>? QualifieldProfessionals { get; set; }
    public double TimeSpent { get; set; }
    public TimeType TimeType { get; set; }
}

public class ProfessionalDto
{
    public string ProfessionalDoc { get; set; } = string.Empty;
}