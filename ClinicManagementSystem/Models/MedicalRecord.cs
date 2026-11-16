namespace ClinicManagementSystem.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        [Required]
        public string Symptoms { get; set; } = string.Empty;

        [Required]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        public string Prescription { get; set; } = string.Empty;

        public string? DoctorNotes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Key
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]

        // Navigation property
        public Appointment Appointment { get; set; } = null!;
    }
}
