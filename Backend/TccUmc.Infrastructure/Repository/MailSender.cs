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

    private async Task MailSmtp(string emailText, MimeMessage message)
    {
        var client = new MailKit.Net.Smtp.SmtpClient();
        
        var host = Environment.GetEnvironmentVariable("SERVER_SMTP")??"";
        var port = int.Parse(Environment.GetEnvironmentVariable("SERVER_PORT_SMTP")??"");
        var mailSender = Environment.GetEnvironmentVariable("MAIL_SENDER")??"";
        var mailSenderPassword = Environment.GetEnvironmentVariable("MAIL_SENDER_PASSWORD")??"";

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