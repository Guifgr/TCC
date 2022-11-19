namespace TccUmc.Domain.Models;

public class Professional : BaseModel
{
    public string ProfessionalDoc { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}