namespace Api.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CprNumber { get; set; }
    public DateTime Birthday { get; set; }
    PatientJournal Journal { get; set; }
}
