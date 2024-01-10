using MimeKit;

namespace Inventory.Utility
{
    public interface IEmailService
    {
        void SendEmail(string from, string toEmail, string subject, string htmlMessage);
        //MimeMessage CreateEmailMessage(Message message);
        //void Send(MimeMessage mailMessage);
    }
}
