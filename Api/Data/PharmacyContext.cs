using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class PharmacyContext: DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public PharmacyContext(DbContextOptions<PharmacyContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<AuditLog>()
            .Property(al => al.Action)
            .HasConversion<string>();
    }
}
