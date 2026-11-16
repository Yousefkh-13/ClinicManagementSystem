
namespace ClinicManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string? WorkingHours { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public int SpecialtyId { get; set; }
        [ForeignKey("SpecialtyId")]
        public Specialty Specialty { get; set; } = null!;

        // Navigation Property
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
