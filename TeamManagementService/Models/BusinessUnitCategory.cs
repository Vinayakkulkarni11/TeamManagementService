
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementService.Models
{
    public class BusinessUnitCategory
    {
        [Key]
        public int BUC_Id { get; set; }

        [ForeignKey("BusinessUnit")]
        public int BU_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZurichLineOfBusiness { get; set; } = string.Empty;

    }
}
