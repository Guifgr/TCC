using AutoMapper;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Consult;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Professional;
using TccUmc.Application.IService;
using TccUmc.Domain.Enums;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Application.Service;

public class ClinicService : IClinicService
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ClinicService(IClinicRepository clinicRepository, IMapper mapper, IUserRepository userRepository)
    {
        _clinicRepository = clinicRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UpdateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);
        clinic = await _clinicRepository.UpdateClinic(clinic);
        return _mapper.Map<UpdateClinicResponseDto>(clinic);
    }

    public async Task<UpdateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto)
    {
        var clinic = await _clinicRepository.GetClinic();
        clinic.WorkingHours = _mapper.Map<List<WorkingHours>>(clinicDto.WorkingHours);
        clinic = await _clinicRepository.UpdateClinicHours(clinic);
        return _mapper.Map<UpdateClinicResponseDto>(clinic);
    }

    public async Task<ProcedureGetDto> CreateClinicProcedure(ProcedurePostDto dto)
    {
        var procedure = _mapper.Map<Procedure>(dto);
        await _clinicRepository.CreateClinicProcedureAsync(procedure);
        return _mapper.Map<ProcedureGetDto>(procedure);
    }

    public async Task<List<ProcedureGetDto>> GetClinicProcedures()
    {
        return _mapper.Map<List<ProcedureGetDto>>(await _clinicRepository.GetClinicProcedures());
    }

    public async Task<ConsultPostDto> CreateConsult(ConsultPostDto consultPost, string userId)
    {
        var user = await _userRepository.GetUserById(int.Parse(userId));
        var consultEntity = new Consult
        {
            User = user,
            ConsultStart = consultPost.ConsultStart,
        };
        
        if (consultPost.Professional != Guid.Empty)
        {
            consultEntity.Professional = await _clinicRepository
                .GetClinicProfessionalByGuid(consultPost.Professional);
        }

        consultEntity.Procedure = await _clinicRepository.GetClinicProcedureByGuid(consultPost.Procedure);
        consultEntity.ConsultEnd = consultEntity.ConsultStart.AddMinutes(consultEntity.Procedure.Duration);
        
        var consults = await _clinicRepository.GetConsultsByDate(consultPost.ConsultStart.Date);
        var hasAppointment = consults
            .Any(c =>
                (c.ConsultStart.TimeOfDay >= consultEntity.ConsultStart.TimeOfDay &&
                c.ConsultStart.TimeOfDay <= consultEntity.ConsultEnd.TimeOfDay) ||
                (c.ConsultEnd.TimeOfDay <= consultEntity.ConsultEnd.TimeOfDay &&
                c.ConsultStart.TimeOfDay >= consultEntity.ConsultEnd.TimeOfDay));

        if (hasAppointment)
        {
            throw new BadRequestException("Já existe uma consulta marcada para este horário");
        }
        
        return _mapper.Map<ConsultPostDto>(await _clinicRepository.CreateConsult(consultEntity));
    }

    public async Task<ProfessionalGetDto> CreateNewProfessional(ProfessionalPostDto professional)
    {
        var professionalEntity = _mapper.Map<Professional>(professional);
        var clinicProfessionals = await _clinicRepository.GetClinicProfessionals();
        if (clinicProfessionals.Any(p => p.ProfessionalDoc == professionalEntity.ProfessionalDoc))
        {
            throw new BadRequestException($"Professional já está cadastrado");
        }
        return _mapper.Map<ProfessionalGetDto>(await _clinicRepository.CreateNewClinicProfessional(professionalEntity));
    }
    
    public async Task<List<ProfessionalGetDto>> GetProfessionals()
    {
        return _mapper.Map<List<ProfessionalGetDto>>(await _clinicRepository.GetClinicProfessionals());
    }

    public async Task<List<ConsultGetDto>> GetUserConsults(string userId)
    {
        return  _mapper.Map<List<ConsultGetDto>>(
            await _clinicRepository.GetConsults(int.Parse(userId), Role.User));
    }

    public async Task<List<ConsultGetDto>> GetClincConsults(string userId)
    {
        return  _mapper.Map<List<ConsultGetDto>>(
            await _clinicRepository.GetConsults(int.Parse(userId), Role.User));
    }
}