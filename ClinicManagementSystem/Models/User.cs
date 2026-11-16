namespace ClinicManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Doctor? DoctorProfile { get; set; }
        public ICollection<Appointment> CreatedAppointments { get; set; } = new List<Appointment>();

    }
}
