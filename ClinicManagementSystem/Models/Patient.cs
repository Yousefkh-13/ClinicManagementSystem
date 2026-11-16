namespace ClinicManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LName { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        public int Age { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? NationalId { get; set; }

        //public string? ChronicDiseases { get; set; }
        //public string? Allergies { get; set; }

        // Navigation Property
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
