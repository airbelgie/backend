using brevo_csharp.Api;
using brevo_csharp.Client;
using brevo_csharp.Model;
using Microsoft.Extensions.Options;

namespace AirBelgie.Service;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    
    public void SendEmail(string toName, string toEmail, string subject, string htmlContent, string textContent)
    {
        Configuration.Default.ApiKey.Add("api-key", _emailSettings.ApiKey);
        TransactionalEmailsApi apiInstance = new TransactionalEmailsApi();
        
        SendSmtpEmailSender sender = new SendSmtpEmailSender("Air Belgie", "noreply@airbelgie.com");
        SendSmtpEmailTo toAddress = new SendSmtpEmailTo(toEmail, toName);
        List<SendSmtpEmailTo> toAddresses = new List<SendSmtpEmailTo>
        {
            toAddress
        };
        try
        {
            SendSmtpEmail sendSmtpEmail = new SendSmtpEmail(sender: sender, to: toAddresses, subject: subject, htmlContent: htmlContent, textContent: textContent);
            CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}