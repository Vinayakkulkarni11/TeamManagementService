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
        [EnumDataType(typeof(BusinessUnitType))]
        public BusinessUnitType BU_Type { get; set; }

    }

    public enum BusinessUnitType
    {
        UW,
        UWS,
        UWSS
    }
}
