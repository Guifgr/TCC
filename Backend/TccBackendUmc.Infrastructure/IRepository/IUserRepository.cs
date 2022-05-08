using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.IRepository;

public interface IUserRepository
{
    User GetUserByCredentials(string email, string password);
    void VerifyUserPassword(string password, User user);
    void SaveLastAccess(User user, DateTime date);
    User GetUserById(int id);
    Task<User> CreateUser(User user);
}