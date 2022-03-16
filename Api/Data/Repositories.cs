using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DoctorRepository : BaseAsyncRepository<Doctor>
{
    public DoctorRepository(PharmacyContext context) : base(context, context.Doctors) 
    { }
}

public class PatientRepository : BaseAsyncRepository<Patient>
{
    public PatientRepository(PharmacyContext context): base(context, context.Patients)
    { }
}

public class PharmacyRepository : BaseAsyncRepository<Pharmacy>
{
    public PharmacyRepository(PharmacyContext context) : base(context, context.Pharmacies)
    { }
}

public class PrescriptionRepository : BaseAsyncRepository<Prescription>
{
    public PrescriptionRepository(PharmacyContext context) : base(context, context.Prescriptions)
    { }

    public override IQueryable<Prescription> CustomQuery()
        => ContextCollection.Include(x => x.Patient);
}