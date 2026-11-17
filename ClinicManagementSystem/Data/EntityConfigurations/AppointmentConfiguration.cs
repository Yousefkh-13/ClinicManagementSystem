namespace ClinicManagementSystem.Data.EntityConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // If someone tries to delete a doctor directly from the database,
            // SQL Server will reject the operation because there are appointments associated with that doctor.
            builder.HasOne(a => a.Doctor)
                   .WithMany(d => d.Appointments)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // If someone tries to delete a user directly from the database, 
            // SQL Server will reject the operation because there are appointments created by that user.
            builder.HasOne(a => a.CreatedByUser)
                   .WithMany(u => u.CreatedAppointments)
                   .HasForeignKey(a => a.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // If someone tries to delete a patient directly from the database
            // SQL Server will reject the operation because there are appointments associated with that patient.
            builder.HasOne(a => a.Patient)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
