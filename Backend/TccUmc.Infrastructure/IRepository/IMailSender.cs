using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IMailSender
{
    Task SentMailResetPassword(string email, string token);
}