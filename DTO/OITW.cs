using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace item_management.DTO
{    
    public class OITWDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string WarehouseCode { get; set; } = string.Empty;
        public decimal QuantityOnHand { get; set; }
        // public OITMDto? Item { get; set; }
    }
}
