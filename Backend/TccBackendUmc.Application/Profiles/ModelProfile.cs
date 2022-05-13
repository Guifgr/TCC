using AutoMapper;
using TccBackendUmc.Application.DTO;
using TccBackendUmc.Application.DTO.Clinic.Request;
using TccBackendUmc.Application.DTO.Users.Request;
using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Application.Profiles;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<AddressDto, Address>();
        CreateMap<Clinic, CreateClinicDto>();
        CreateMap<CreateClinicDto, Clinic>();
        CreateMap<Clinic, UpdateClinicDto>();
        CreateMap<UpdateClinicDto, Clinic>();
        CreateMap<WorkingHoursDto, WorkingHours>();
        CreateMap<WorkingHours, WorkingHoursDto>();
    }
}