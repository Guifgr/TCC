namespace TccUmc.Domain.Models;

public class Clinic
{
    public int Id { get; set; }
    public string? Cnpj { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Whatsapp { get; set; } = string.Empty;
    public List<WorkingHours> WorkingHours { get; set; } = new();
    public List<Procedure>? Procedures { get; set; } = new();
    public List<Consult>? Consults { get; set; } = new();
    public List<Professional> Professionals { get; set; } = new();
}