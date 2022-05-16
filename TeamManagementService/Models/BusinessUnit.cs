global using System.ComponentModel.DataAnnotations;

namespace TeamManagementService.Models
{
    public class BusinessUnit
    {
        [Key]
        public int BU_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string BU_Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string BU_Description { get; set; } = string.Empty;

        [Required]
        public bool Active { get; set; }

        [Required]
        [MaxLength(4)]
        public string BU_Type { get; set; } = string.Empty;

    }
}
