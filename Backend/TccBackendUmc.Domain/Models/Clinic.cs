namespace TccBackendUmc.Domain.Models;

public class Clinic : UserBaseModel
{
    public string Cnpj { get; set; }
    public List<Professional> Professionals { get; set; }
    
}