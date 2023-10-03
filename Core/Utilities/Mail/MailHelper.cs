using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail;

public class MailHelper : IMailHelper
{
    private readonly string _host;
    private readonly int _port;
    
    private readonly string _from;

    private readonly SmtpClient _smtpClient;

    public MailHelper(IConfiguration configuration)
    {
        _host = configuration["Smtp:Host"];
        _port = int.Parse(configuration["Smtp:Port"]);

        _from = configuration["Smtp:From"];

        _smtpClient = new SmtpClient();
    }

    public async Task SendMailAsync(string subject, string body, string recepients)
    {
        try
        {
            await _smtpClient.ConnectAsync(host: _host, port: _port, useSsl: false);

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_from));
            email.To.AddRange(InternetAddressList.Parse(recepients));

            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = body };

            await _smtpClient.SendAsync(email);
        }
        catch (Exception)
        {
        }
        finally
        {
            if (_smtpClient.IsConnected)
            {
                await _smtpClient.DisconnectAsync(true);
            }
        }
    }
}
