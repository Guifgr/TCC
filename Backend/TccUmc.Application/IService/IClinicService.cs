using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;

namespace TccUmc.Application.IService;

public interface IClinicService
{
    Task<CreateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto);
    Task<CreateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto);
}