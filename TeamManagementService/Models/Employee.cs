namespace TeamManagementService.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(500)]
        public string Emp_LoginID { get; set; } = string.Empty;

        [ForeignKey("BusinessUnits")]
        public int BU_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(3)]
        public string Status { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

    }
}
