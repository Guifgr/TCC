using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Application.DTO.Clinic.Request;

public class UpdateClinicWorkingHoursDto
{
    public List<WorkingHoursDto> WorkingHours { get; set; }
}