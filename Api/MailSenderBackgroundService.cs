using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api;

public class MailSenderBackgroundService: BackgroundService
{
    private readonly MailSenderBackgroundSettings _settings;
    private readonly ILogger<MailSenderBackgroundService> _logger;
    private readonly IAsyncRepository<Prescription> _repository;

    public MailSenderBackgroundService(IOptions<MailSenderBackgroundSettings> settings, ILogger<MailSenderBackgroundService> logger, IAsyncRepository<Prescription> repository)
    {
        _settings = settings.Value;
        _logger = logger;
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("MailSenderBackgroundService is starting.");

        stoppingToken.Register(() =>
            _logger.LogInformation(" MailSender background task is stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogDebug("MailSender task is checking for mails to send.");

            await foreach(Prescription prescription in CheckForExpiringPrescriptions())
            {
                if (stoppingToken.IsCancellationRequested)
                    break;

                await SendMails(prescription);

                prescription.HasBeenNotified = true;
                await _repository.Update(prescription.Id, prescription);
            }

            await Task.Delay(_settings.CheckForMailToSendIntervalSec * 1000, stoppingToken);
        }

        _logger.LogDebug("MailSender background task is stopping.");
    }

    protected IAsyncEnumerable<Prescription> CheckForExpiringPrescriptions()
        => _repository
                   .CustomQuery()
                   .Where(x =>
                       DateTime.Now < x.ExpirationDate
                       && DateTime.Now > x.ExpirationDate.AddHours(-1 * _settings.ExperationDateIntervalLengthHours)
                       && !x.IsFulfilled
                       && !x.HasBeenNotified)
            .AsAsyncEnumerable();

    protected async Task SendMails(Prescription prescription)
    {
        
        Patient patient = prescription.Patient;
        string messageBody = @$"Hi {patient.FirstName} {patient.LastName}, 
This is a reminder that your prescription for {prescription.Dosage} {prescription.DosageForm} of {prescription.Medication} issued to you on {prescription.PerscriptionDate.ToLongDateString()} is about to expire.

Please retrive your prescription from a phamacy before {prescription.ExpirationDate.ToLongDateString()} or you will have to get a new prescription from your doctor.

Best Regards World Champions Medical Inc";

        SmtpClient smtpClient = new(_settings.SmtpHostAddress, _settings.SmtpPort);
        await smtpClient.SendMailAsync("noreply@WorldChampionsMedicalInc.com", prescription.Patient.Email, "Your prescription is about to expire!", messageBody);
    }
}

