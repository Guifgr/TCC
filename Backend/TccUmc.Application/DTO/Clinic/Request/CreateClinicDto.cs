using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Clinic.Request;

public class CreateClinicDto
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Whatsapp { get; set; }
    List<WorkingHoursDto> WorkingHours { get; set; }
}