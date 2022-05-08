using TccBackendUmc.Domain.Exceptions;
using TccBackendUmc.Domain.Models;
using TccBackendUmc.Infrastructure.Database.Context;
using TccBackendUmc.Infrastructure.IRepository;

namespace TccBackendUmc.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly MssqlContext _mssqlContext;

    public UserRepository(MssqlContext mssqlContext)
    {
        _mssqlContext = mssqlContext;
    }

    public User GetUserByCredentials(string email, string password)
    {
        var result = _mssqlContext.Users.FirstOrDefault(u =>
            u.Email == email
        );
        if (result == null)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        return result;
    }

    public void SaveLastAccess(User user, DateTime date)
    {
        var result = _mssqlContext.Users.FirstOrDefault(u => u.Id == user.Id);

        if (result == null)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        _mssqlContext.SaveChanges();
    }

    public void VerifyUserPassword(string password, User user)
    {
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            throw new BadRequestException("Usuário ou senha incorretos");
        }
    }

    public User GetUserById(int id)
    {
        var user = _mssqlContext.Users.FirstOrDefault(u => u.Id == id);
        if (user == default)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        await _mssqlContext.Users.AddAsync(user);
        await _mssqlContext.SaveChangesAsync();
        return user;
    }
}