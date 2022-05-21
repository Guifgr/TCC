using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IMailSender
{
    Task<bool> SentMailResetPassword(string email, string token);
}