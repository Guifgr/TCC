using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Consult;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Professional;

namespace TccUmc.Application.IService;

public interface IClinicService
{
    Task<UpdateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto);
    Task<UpdateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto);
    Task<ProcedureGetDto> CreateClinicProcedure(ProcedurePostDto dto);
    Task<List<ProcedureGetDto>> GetClinicProcedures();
    Task<List<ProcedureGetDto>> GetClinicProcedureByGuid(Guid guid);
    Task<ConsultPostDto> CreateConsult(ConsultPostDto consultPost, string userId);
    Task<ProfessionalGetDto> CreateNewProfessional(ProfessionalPostDto professional);
    Task<List<ProfessionalGetDto>> GetProfessionals();
    Task<List<ConsultGetDto>> GetUserConsults(string userId);
    Task<List<ConsultGetDto>> GetClincConsults(string userId);
    Task<List<ProcedureGetDto>> PutClinicProcedure(ProcedureGetDto procedure);
    Task<ConsultPostDto> CreateConsultClinic(ConsultPostDto consultPost, Guid userGuid);
    Task<List<UserDTO>> GetUsers();
    Task DeleteConsult(Guid guid, string userId);
    Task DeleteConsultClinic(Guid consultGuid);
}