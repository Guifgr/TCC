using TccBackendUmc.Application.DTO.Clinic.Request;
using TccBackendUmc.Application.DTO.Clinic.Response;

namespace TccBackendUmc.Application.Interfaces;

public interface IClinicService
{
    Task<CreateClinicResponseDto> CreateClinic(CreateClinicDto request, int userId);
    Task<CreateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto, int userId);
    Task<CreateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto, int clinicId);
}