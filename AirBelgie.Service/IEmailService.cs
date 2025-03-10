namespace AirBelgie.Service;

public interface IEmailService
{
    void SendEmail(string toName, string toEmail, string subject, string htmlContent, string textContent);
}