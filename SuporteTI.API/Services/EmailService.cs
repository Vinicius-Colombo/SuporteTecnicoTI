using Azure;
using Azure.Communication.Email;
using Microsoft.Extensions.Options;

namespace SuporteTI.API.Services
{

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly EmailClient _client;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
            _client = new EmailClient(_settings.ConnectionString);
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            if (_settings.FromEmail is null)
                throw new Exception("FromEmail não configurado nas variáveis de ambiente.");

            // Monte o remetente com nome personalizado
            string sender = $"{_settings.FromName} <{_settings.FromEmail}>";

            var emailMessage = new EmailMessage(
                senderAddress: _settings.FromEmail,
                content: new EmailContent(subject)
                {
                    Html = htmlBody,
                    PlainText = "Você recebeu um novo e-mail do sistema SuporteTI."
                },
                recipients: new EmailRecipients(new List<EmailAddress>
                {
                    new EmailAddress(to)
                })
            );

            await _client.SendAsync(WaitUntil.Completed, emailMessage);
        }
    }
}
