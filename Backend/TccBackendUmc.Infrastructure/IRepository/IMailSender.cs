using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.IRepository;

public interface IMailSender
{
    Task<bool> SentMailFirstAccess(string email, string token);
}