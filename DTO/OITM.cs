using System;

namespace item_management.DTO
{
    public class OITMDto
    {
        public int Id { get; set; }
        
        public string ItemCode { get; set; } = string.Empty;
        
        public string ItemName { get; set; } = string.Empty;
        
        public string ItemGroup { get; set; } = string.Empty;
        
        public string? OUGPId { get; set; } = string.Empty;
        
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        
        // public ICollection<OITWDto> OITWDtos { get; set; } = new List<OITWDto>();
    }  
}

