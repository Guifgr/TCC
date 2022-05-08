using AutoMapper;
using TccBackendUmc.Application.DTO.Request;
using TccBackendUmc.Application.DTO.Request.Users;
using TccBackendUmc.Application.DTO.Response.User;
using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Application.Profiles;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<AddressDto, Address>();
    }
}