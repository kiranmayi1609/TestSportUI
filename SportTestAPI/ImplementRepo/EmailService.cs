using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using SportTestAPI.IGenericRepo;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace SportTestAPI.ImplementRepo
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {

            var smtpSettings = _configuration.GetSection("SmtpSettings");

            using(var client=new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"])))
            {
                client.Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]);
                client.EnableSsl = bool.Parse(smtpSettings["EnableSsl"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["FromEmail"],"SPORT"),
                    Subject=subject,
                    Body=body,
                    IsBodyHtml=true 

                };
                mailMessage.To.Add(toEmail);
                await client.SendMailAsync(mailMessage);

            }
            Console.WriteLine($"[SMTP Email sent] To :{toEmail},Subject:{subject}");
            


            
        }
    }
}
