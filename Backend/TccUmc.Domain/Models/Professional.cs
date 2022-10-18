namespace TccUmc.Domain.Models;

public class Professional : UserBaseModel
{
    public int Id { get; set; }
    public string ProfessionalDoc { get; set; } = string.Empty;
}