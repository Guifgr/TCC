using AutoMapper;
using TccUmc.Application.DTO;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Domain.Models;

namespace TccUmc.Application.Profiles;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, CreateUserResponseDto>();
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();
        CreateMap<Clinic, UpdateClinicResponseDto>();
        CreateMap<UpdateClinicResponseDto, Clinic>();
        CreateMap<Clinic, UpdateClinicDto>();
        CreateMap<UpdateClinicDto, Clinic>();
        CreateMap<WorkingHoursDto, WorkingHours>();
        CreateMap<WorkingHours, WorkingHoursDto>();
    }
}