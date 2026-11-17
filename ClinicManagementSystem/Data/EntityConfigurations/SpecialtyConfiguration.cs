namespace ClinicManagementSystem.Data.EntityConfigurations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            
            builder.Property(s => s.CheckupPrice).HasColumnType("decimal(18,2)");
        }

    }
}
