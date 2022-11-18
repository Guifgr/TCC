using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class Procedure : BaseModel
{
    public string Name { get; set; }
    public List<Professional> QualifieldProfessionals { get; set; }
    public double Duration { get; set; }

}