using AutoMapper;
using TccUmc.Application.DTO;
using TccUmc.Application.DTO.Clinic.Request;
using TccUmc.Application.DTO.Clinic.Response;
using TccUmc.Application.DTO.Consult;
using TccUmc.Application.DTO.Procedures;
using TccUmc.Application.DTO.Professional;
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
        CreateMap<Professional, ProfessionalGetDto>().ReverseMap();
        CreateMap<Professional, ProfessionalPostDto>().ReverseMap();
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<Clinic, UpdateClinicResponseDto>().ReverseMap();
        CreateMap<Clinic, UpdateClinicDto>().ReverseMap();
        CreateMap<WorkingHoursDto, WorkingHours>().ReverseMap();
        CreateMap<ProcedureGetDto, Procedure>().ReverseMap();
        CreateMap<ProcedurePostDto, Procedure>().ReverseMap();
        CreateMap<ConsultPostDto, Consult>().ReverseMap();
        CreateMap<ConsultGetDto, Consult>().ReverseMap();
        CreateMap<Dashboard, DashboardGetDto>().ReverseMap();
    }
}