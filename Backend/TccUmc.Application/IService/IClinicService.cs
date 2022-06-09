using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;

namespace TccUmc.Application.IService;

public interface IClinicService
{
    Task<UpdateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto);
    Task<UpdateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto);
}