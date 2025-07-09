using System.ComponentModel.DataAnnotations;
using item_management.Models;
namespace item_management.Models
{
    public class OITM
    {
        public int Id { get; set; }
        
        [Required, StringLength(50)]
        public string ItemCode { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string ItemName { get; set; } = string.Empty;
        
        [Required, StringLength(100)]
        public string ItemGroup { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? OUGPId { get; set; } = string.Empty;
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public ICollection<OITW> OITW { get; set; } = new List<OITW>();
    }
}