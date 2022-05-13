using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByCredentials(string email, string password);
    void VerifyUserPassword(string password, User user);
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User user);
}