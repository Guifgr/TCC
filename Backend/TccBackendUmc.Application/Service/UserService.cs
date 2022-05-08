using AutoMapper;
using TccBackendUmc.Application.DTO.Request.Users;
using TccBackendUmc.Application.DTO.Response.User;
using TccBackendUmc.Application.Interfaces;
using TccBackendUmc.Domain.Models;
using TccBackendUmc.Infrastructure.IRepository;

namespace TccBackendUmc.Application.Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user = await _userRepository.CreateUser(user);
        return new CreateUserResponseDto
        {
            UserGuid = user.Guid,
            Email = user.Email
        };
    }
}