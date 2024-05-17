using Microsoft.Extensions.Logging;

namespace SurveysPortal.Modules.Notifications.Api.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    //private readonly IMailService _mailService;

    public EmailSender(
        ILogger<EmailSender> logger
        //,
        // IMailService mailService
    )
    {
        _logger = logger;
        // _mailService = mailService;
    }

    public EmailSender()
    {
    }

    public Task SendAsync(string receiver, string template)
    {
        // var mail = new Mail(
        //     $"CBST - notification",
        //     template,
        //     new List<string>() { "karol.maliglowka@zf.com" },
        //     new()
        // );
        //
        // _mailService.SendEmail(mail);


        _logger.LogInformation($"Sending an email to: '{receiver}', template: '{template}'...");
        return Task.CompletedTask;
    }
}