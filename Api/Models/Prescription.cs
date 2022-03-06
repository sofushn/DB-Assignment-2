namespace Api.Models;

public class Prescription
{
    public int Id { get; set; }
    public string Medication { get; set; }
    public string Dosage { get; set; }
    public string DosageForm { get; set; }
    public int NumberOfRefillsLeft { get; set; }
    public string DispensingInstructions { get; set; }
    public byte[] Signature { get; set; }
    public bool IsFulfilled { get; set; }
    public DateTime PerscriptionDate { get; set; }
    public DateTime ExperationDate { get; set; }

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}
