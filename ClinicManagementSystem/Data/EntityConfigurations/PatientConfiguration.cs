namespace ClinicManagementSystem.Data.EntityConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Unique constraint on NationalId to ensure no two patients have the same NationalId
            builder.HasIndex(p => p.NationalId).IsUnique();
        }

    }
}
