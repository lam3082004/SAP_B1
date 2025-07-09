using System;
using item_management.DTO;
using item_management.Models;
namespace item_management.DTO
{
    public class OWHSDto
    {
        public int Id { get; set; }
        public string WhsCode { get; set; } = string.Empty;
        public string WhsName { get; set; } = string.Empty;
        // public List<OITWDto> Items { get; set; } = [];
        // public ICollection<OITW> OITW { get; set; } = new List<OITW>();
    }
}
