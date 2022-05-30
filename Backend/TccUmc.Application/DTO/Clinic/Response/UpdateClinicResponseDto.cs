using TccUmc.Domain.Models;

namespace TccUmc.Application.DTO.Clinic.Response;

public class UpdateClinicResponseDto
{
    public string Name { get; set; }
    public AddressDto Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Whatsapp { get; set; }
    public List<WorkingHoursDto> WorkingHours { get; set; }
}