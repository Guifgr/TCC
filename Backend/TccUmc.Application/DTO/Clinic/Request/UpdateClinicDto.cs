namespace TccUmc.Application.DTO.Clinic.Request;

public class UpdateClinicDto
{
    public string Name { get; set; }
    public AddressDto Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Whatsapp { get; set; }
    public List<WorkingHoursDto> WorkingHours { get; set; }
}