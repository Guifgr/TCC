using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using Microsoft.EntityFrameworkCore;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly TccContext _tccContext;

    public UserRepository(TccContext tccContext)
    {
        _tccContext = tccContext;
    }

    public async Task<User> GetUserByCredentials(string email)
    {
        var result = await _tccContext.Users.FirstOrDefaultAsync(u =>
            u.Email == email
        );
        if (result == null)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        return result;
    }

    public void VerifyUserPassword(string password, User user)
    {
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            throw new BadRequestException("Usuário ou senha incorretos");
        }
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _tccContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == default)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        return user;
    }

    public Task<User?> GetUserByEmail(string userDtoEmail)
    {
        return _tccContext.Users.FirstOrDefaultAsync(x => x.Email == userDtoEmail);
    }

    public async Task<User> CreateUser(User user)
    {
        await _tccContext.Users.AddAsync(user);
        await _tccContext.SaveChangesAsync();
        return user;
    }
}