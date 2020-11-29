using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.Common.Extensions;
using DIMS_Core.Mailer.Configs;
using DIMS_Core.Mailer.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace DIMS_Core.Mailer.Services
{
    public class Sender : ISender
    {
        private const string LayoutHtml =
            "<div style=\"margin-top: 20px;\">Best regards, Dev Incubator Inc.</div>"
            + "<div><img src=\"https://i.ibb.co/9tSLsd6/logo-name.png\" style=\"margin-top:26px; width:250px !important; height:100px !important;\"/>"
            + "</div>";

        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger _logger;

        public Sender(ILogger logger)
        {
            var config = new MailerCofiguration();

            _smtpSettings = config.SmtpSettings;
            _logger = logger;
        }

        public async Task<bool> SendMessage(
            string subject,
            string body,
            params string[] emails)
        {
            using var smtpClient = new SmtpClient();
            
            var isValid = false;

            smtpClient.MessageSent += (sender, e) =>
                                      {
                                          _logger?.LogInformation("Message was sent to {$email}. Response: {$response}.",
                                                                  emails.ToSeparatedString("; "),
                                                                  e.Response);

                                          isValid = true;
                                      };

            await smtpClient.ConnectAsync(_smtpSettings.Server,
                                          _smtpSettings.Port,
                                          _smtpSettings.EnableSsl);

            await smtpClient.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);

            var mailMessage = GenerateMessage(subject,
                                              body,
                                              emails);
            await smtpClient.SendAsync(mailMessage);

            await smtpClient.DisconnectAsync(true);

            return isValid;
        }

        private MimeMessage GenerateMessage(
            string subject,
            string body,
            params string[] to)
        {
            var bodyBuilder = new BodyBuilder
                              {
                                  HtmlBody = body + LayoutHtml
                              };

            var message = new MimeMessage
                          {
                              Body = bodyBuilder.ToMessageBody(),
                              Subject = subject
                          };

            message.From.Add(new MailboxAddress(_smtpSettings.UserName, _smtpSettings.UserName));
            message.To.AddRange(to.Select(q => new MailboxAddress(q, q)));

            return message;
        }
    }
}