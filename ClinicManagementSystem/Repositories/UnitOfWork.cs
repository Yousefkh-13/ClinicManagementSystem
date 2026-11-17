using ClinicManagementSystem.Data;

namespace ClinicManagementSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<Doctor> Doctors { get; private set; }
        public IGenericRepository<Patient> Patients { get; private set; }
        public IGenericRepository<Specialty> Specialties { get; private set; }
        public IGenericRepository<Appointment> Appointments { get; private set; }
        public IGenericRepository<MedicalRecord> MedicalRecords { get; private set; }
        public IGenericRepository<User> Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Doctors = new GenericRepository<Doctor>(_context);
            Patients = new GenericRepository<Patient>(_context);
            Specialties = new GenericRepository<Specialty>(_context);
            Appointments = new GenericRepository<Appointment>(_context);
            MedicalRecords = new GenericRepository<MedicalRecord>(_context);
            Users = new GenericRepository<User>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
