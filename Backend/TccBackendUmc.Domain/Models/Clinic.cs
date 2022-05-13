namespace TccBackendUmc.Domain.Models;

public class Clinic
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Cnpj { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Whatsapp { get; set; }
    public List<User> Owners { get; set; }
    public WorkingHours WorkingHours { get; set; }
    public List<Professional> Professionals { get; set; }
}
