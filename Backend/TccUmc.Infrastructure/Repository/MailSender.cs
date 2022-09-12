using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class MailSender : IMailSender
{
    private readonly IConfiguration _configuration;

    public MailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SentMailResetPassword(string email, string token)
    {
        var emailText = $"https://Tcc.guifgr.com/definir-senha?token={HttpUtility.HtmlEncode(token)}\n";
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("TCC UMC", Environment.GetEnvironmentVariable("MAIL_SENDER")));
        message.To.Add(MailboxAddress.Parse(email));

        message.Subject = "Resetar sua senha TCC UMC";
        message.Body = new TextPart("plain")
        {
            Text = "Clique abaixo para definir senha\n" + emailText
        };

        await MailSmtp(emailText, message);
    }

    public async Task SentMailResetValidateAccount(string userEmail, string validationToken)
    {
        var emailText = $"https://Tcc.guifgr.com/validar-conta?token={HttpUtility.HtmlEncode(validationToken)}\n";
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("TCC UMC", Environment.GetEnvironmentVariable("MAIL_SENDER")));
        message.To.Add(MailboxAddress.Parse(userEmail));

        message.Subject = "Validar conta do TCC UMC";
        message.Body = new TextPart("plain")
        {
            Text = "Clique abaixo para validar a sua conta\n" + emailText
        };

        await MailSmtp(emailText, message);
    }

    private async Task MailSmtp(string emailText, MimeMessage message)
    {
        var client = new SmtpClient();

        var host = Environment.GetEnvironmentVariable("SERVER_SMTP") ?? "";
        var port = int.Parse(Environment.GetEnvironmentVariable("SERVER_PORT_SMTP") ?? "");
        var mailSender = Environment.GetEnvironmentVariable("MAIL_SENDER") ?? "";
        var mailSenderPassword = Environment.GetEnvironmentVariable("MAIL_SENDER_PASSWORD") ?? "";

        try
        {
            await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(mailSender, mailSenderPassword);
            await client.SendAsync(message);
            Console.WriteLine(emailText);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}