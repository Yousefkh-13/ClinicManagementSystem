namespace ClinicManagementSystem.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Unique constraint on Email to ensure no two users have the same email address
            builder.HasIndex(u => u.Email).IsUnique();
        }

    }
}
