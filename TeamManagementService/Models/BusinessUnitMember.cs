
namespace TeamManagementService.Models
{
    public class BusinessUnitMember
    {
        [Key]
        public int BUM_Id { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BU_Id { get; set; }

        [Required]
        [MaxLength(500)]
        [ForeignKey("Employee")]
        public string EmployeeLoginId { get; set; } = string.Empty;

        public bool IsManager { get; set; }


    }
}
