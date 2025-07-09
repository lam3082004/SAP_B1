using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using item_management.Models;
namespace item_management.Models
{    
    public class OITW
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        [Required]
        public int ItemId { get; set; }
        
        [Required]
        [JsonIgnore]
        [StringLength(50)]
        public string WarehouseCode { get; set; } = string.Empty;
        
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
        public decimal QuantityOnHand { get; set; }
        [JsonIgnore]
        public OITM? Item { get; set; }
    }
}
