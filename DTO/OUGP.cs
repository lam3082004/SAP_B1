using System;
using item_management.Models;
using System.Collections.Generic;
namespace item_management.DTO
{
    public class OUGPDto
    {
            public int Id { get; set; }
            public string Code { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public int BaseUom { get; set; }
            // public OUOM? BaseUnit { get; set; }
            // public ICollection<UGP1> UGP1 { get; set; } = new List<UGP1>();
    }

}

