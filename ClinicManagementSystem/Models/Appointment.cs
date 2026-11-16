namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required, MaxLength(20)]
        public string AppointmentStatus { get; set; } = "Scheduled";

        public bool IsPaid { get; set; } = false;


        // Foreign Keys
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; } = null!;

        public int CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public User CreatedByUser { get; set; } = null!;


        // Navigation Property 
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
