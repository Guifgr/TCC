using AutoMapper;
using TccUmc.Application.DTO;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Domain.Models;

namespace TccUmc.Application.Profiles;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, CreateUserResponseDto>();
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<Clinic, UpdateClinicResponseDto>().ReverseMap();
        CreateMap<Clinic, UpdateClinicDto>().ReverseMap();
        CreateMap<WorkingHoursDto, WorkingHours>().ReverseMap();
        CreateMap<ClinicProcedureDto, ClinicProcedure>().ReverseMap();
        CreateMap<ClinicProcedureCreateDto, ClinicProcedure>().ReverseMap();
    }
}