using TccUmc.Domain.Enums;

namespace TccUmc.Domain.Models;

public class Procedure : BaseModel
{
    public string Name { get; set; }
    public List<Professional> QualifieldProfessionals { get; set; } = new List<Professional>();
    public double Duration { get; set; }
    public double Price { get; set; }
}