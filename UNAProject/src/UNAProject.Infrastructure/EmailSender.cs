// <copyright file="EmailSender.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UNAProject.Core.Interfaces;
using UNAProject.Infrastructure.Configurations;

namespace UNAProject.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        private readonly EmailConfiguration _emailconfiguration;

        public EmailSender(ILogger<EmailSender> logger, IOptions<EmailConfiguration> emailconfiguration)
        {
            _logger = logger;
            _emailconfiguration = emailconfiguration.Value;
        }

        public async Task SendEmailAsync(string from, string subject, string body, string to = "")
        {
            using (var emailClient = new SmtpClient(_emailconfiguration.Host, _emailconfiguration.Port))
            using (var message = new MailMessage())
            {
                emailClient.Credentials = new NetworkCredential(_emailconfiguration.Username, _emailconfiguration.Password);
                emailClient.EnableSsl = true;

                message.From = new MailAddress(from);
                message.Subject = subject;
                message.Body = body;

                if (string.IsNullOrEmpty(to))
                {
                    to = _emailconfiguration.AdminEmail;
                }

                message.To.Add(new MailAddress(to));

                await emailClient.SendMailAsync(message);
            }

            _logger.LogWarning($"Sending email to {to} from {from} with subject {subject}.");
        }
    }
}
