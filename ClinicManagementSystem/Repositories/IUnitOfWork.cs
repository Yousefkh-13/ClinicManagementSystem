namespace ClinicManagementSystem.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Doctor> Doctors { get; }
        IGenericRepository<Patient> Patients { get; }
        IGenericRepository<Specialty> Specialties { get; }
        IGenericRepository<Appointment> Appointments { get; }
        IGenericRepository<MedicalRecord> MedicalRecords { get; }
        IGenericRepository<User> Users { get; }

        Task<int> CompleteAsync();
    }
}
