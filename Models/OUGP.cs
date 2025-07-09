using System;
using item_management.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace item_management.Models;

  public class OUGP
{
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int BaseUom { get; set; }
        [JsonIgnore]
        public OUOM? BaseUnit { get; set; }
        public ICollection<UGP1> UGP1 { get; set; } = new List<UGP1>();
}
