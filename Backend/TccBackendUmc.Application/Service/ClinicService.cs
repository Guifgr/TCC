using AutoMapper;
using TccBackendUmc.Application.DTO.Clinic.Request;
using TccBackendUmc.Application.DTO.Clinic.Response;
using TccBackendUmc.Application.Interfaces;
using TccBackendUmc.Domain.Models;
using TccBackendUmc.Infrastructure.Interfaces;

namespace TccBackendUmc.Application.Service;

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

    public async Task<CreateClinicResponseDto> CreateClinic(CreateClinicDto request, int userId)
    {
        var clinic = _mapper.Map<Clinic>(request);
        clinic.Owners = new List<User> { await _userRepository.GetUserById(userId) };
        clinic = await _clinicRepository.CreateClinic(clinic);
        return _mapper.Map<CreateClinicResponseDto>(clinic);
    }

    public async Task<CreateClinicResponseDto> UpdateClinic(UpdateClinicDto clinicDto, int userId)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);
        clinic = await _clinicRepository.UpdateClinic(clinic);
        return _mapper.Map<CreateClinicResponseDto>(clinic);
    }

    public async Task<CreateClinicResponseDto> UpdateClinicWorkingHours(UpdateClinicWorkingHoursDto clinicDto, int clinicId)
    {
        var clinic = await _clinicRepository.GetClinicById(clinicId);
        clinic.WorkingHours = _mapper.Map<WorkingHours>(clinicDto); 
        clinic= await _clinicRepository.UpdateClinic(clinic);
        return _mapper.Map<CreateClinicResponseDto>(clinic);
    }
}