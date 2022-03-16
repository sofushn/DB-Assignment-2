namespace Api.Models;

public class Patient: EntityWithId
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CprNumber { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }

    internal ICollection<Prescription> Prescriptions { get; set; }
}
