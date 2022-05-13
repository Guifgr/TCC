namespace TccBackendUmc.Infrastructure.Interfaces;

public interface IMailSender
{
    Task<bool> SentMailFirstAccess(string email, string token);
}