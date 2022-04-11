using System.ComponentModel.DataAnnotations;

namespace Api;

public class MailSenderBackgroundSettings
{
    [PositiveInt]
    public int CheckForMailToSendIntervalSec { get; set; }
    [PositiveInt]
    public int ExperationDateIntervalLengthHours { get; set; }
    public string SmtpHostAddress { get; set; } = "localhost";
    public int SmtpPort { get; set; } = 25;
}

public class PositiveIntAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        int intVal = (int)(value ??= 0);
        return intVal >= 0;
    }
}
