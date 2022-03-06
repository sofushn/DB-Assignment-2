using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class PharmacyContext: DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

    public PharmacyContext(DbContextOptions<PharmacyContext> options): base(options) { }
}
