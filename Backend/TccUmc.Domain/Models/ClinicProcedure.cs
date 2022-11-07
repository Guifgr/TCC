using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class ClinicProcedure : BaseModel
{
    public string Name { get; set; }
    public List<Professional>? QualifieldProfessionals { get; set; }
    public double TimeSpent { get; set; }
    public TimeType TimeType { get; set; }

}