using System.Web;
using TccUmc.Domain.Models;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Utility.Extensions;

namespace TccUmc.Infrastructure.Repository;

public class MailSender : IMailSender
{
    private readonly IConfiguration _configuration;
    private readonly string _mailSender;
    private readonly string _mailSenderPassword;

    public MailSender(IConfiguration configuration)
    {
        _configuration = configuration;
        _mailSender = EnvironmentVariableExtension.GetEnvironmentVariable<string>("", "MAILSERVER:MAIL_SENDER");
        _mailSenderPassword = EnvironmentVariableExtension.GetEnvironmentVariable<string>("", "MAILSERVER:MAIL_SENDER_PASSWORD");
    }
    
    public async Task<bool> SentMailResetPassword(string email, string token)
    {
        var emailText = $"https://Tcc.guifgr.com/definirSenha?token={HttpUtility.HtmlEncode(token)}\n";
        var message = new MimeMessage();
        
        message.From.Add(new MailboxAddress("TCC UMC", _mailSender));
        message.To.Add(MailboxAddress.Parse(email));

        message.Subject = "Resetar sua senha TCC UMC";
        message.Body = new TextPart("plain")
        {
            Text = "Clique abaixo para definir senha\n" + emailText
        };

        return await MailSmtp(emailText, message);
    }

    private async Task<bool> MailSmtp(string emailText, MimeMessage message)
    {
        var client = new MailKit.Net.Smtp.SmtpClient();
        var configs = _configuration.GetSection("MAILSERVER");

        var host = configs.GetValue<string>("SERVER_SMTP");
        var port = configs.GetValue<int>("SERVER_PORT_SMTP");

        try
        {
            await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_mailSender, _mailSenderPassword);
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

        return true;
    }
}   