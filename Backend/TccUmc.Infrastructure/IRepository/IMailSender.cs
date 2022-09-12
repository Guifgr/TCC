namespace TccUmc.Infrastructure.IRepository;

public interface IMailSender
{
    Task SentMailResetPassword(string email, string token);
    Task SentMailResetValidateAccount(string userEmail, string validationToken);
}