using System.Threading.Tasks;
using LaborU.Models;
using LaborU.Models.Entity.Identity;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace LaborU.Services;

public class EmailSender : IEmailSender<LaborUUser>
{
    private IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task SendConfirmationLinkAsync(LaborUUser user, string email, string confirmationLink)
    {
        return SendMail(new MailboxAddress(user.UserName, email), confirmationLink);
    }

    private async Task SendMail(MailboxAddress receiver, string emailBodyText)
    {
        var smtpConfiguration = _configuration.GetSection("SMTP").Get<EmailConfiguration>();
        using var smtpClient = new SmtpClient();
        await smtpClient.ConnectAsync(smtpConfiguration.Host, smtpConfiguration.Port, smtpConfiguration.UseSSL);
        await smtpClient.AuthenticateAsync(smtpConfiguration.UserName, smtpConfiguration.Password);
        await smtpClient.SendAsync(new MimeMessage()
        {
            Subject = "LaborU 信箱驗證信",
            Sender = new MailboxAddress(smtpConfiguration.SenderName, smtpConfiguration.Sender),
            To = { receiver },
            Body = new TextPart("html")
            {
                Text = emailBodyText
            }
        });
    }

    public Task SendPasswordResetLinkAsync(LaborUUser user, string email, string resetLink)
    {
        return SendMail(new MailboxAddress(user.UserName, email), resetLink);
    }

    public Task SendPasswordResetCodeAsync(LaborUUser user, string email, string resetCode)
    {
        return SendMail(new MailboxAddress(user.UserName, email), resetCode);
    }
}