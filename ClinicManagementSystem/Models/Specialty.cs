namespace ClinicManagementSystem.Models
{
    public class Specialty
    {
        public int Id { get; set; }


        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        
        [Column(TypeName = "decimal(18,2)]")]
        public decimal CheckupPrice { get; set; }
        
        public bool IsActive { get; set; } = true;

        // Navigation property
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
