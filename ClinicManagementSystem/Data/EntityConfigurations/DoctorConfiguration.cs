namespace ClinicManagementSystem.Data.EntityConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // Global Query Filter: Any standard query will return only active doctors
            builder.HasQueryFilter(d => !d.IsDeleted);

            // Prevent cascade deletes to preserve medical history
            builder.HasOne(d => d.Specialty)
                   .WithMany(s => s.Doctors)
                   .HasForeignKey(d => d.SpecialtyId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
