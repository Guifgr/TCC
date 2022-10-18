using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Procedures;

namespace TccUmc.Application.IService;

public interface IClinicService
{
    Task<UpdateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto);
    Task<UpdateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto);
    Task<ClinicProcedureDTO> CreateClinicProcedure(ClinicProcedureCreateDTO clinicDto);
}