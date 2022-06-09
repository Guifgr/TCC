using AutoMapper;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Application.Service;

public class ClinicService : IClinicService
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IMapper _mapper;

    public ClinicService(IClinicRepository clinicRepository, IMapper mapper, IUserRepository userRepository)
    {
        _clinicRepository = clinicRepository;
        _mapper = mapper;
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
}