using System;
using System.Text.Json.Serialization;
using item_management.Models;
namespace item_management.Models;

public class UGP1
{
    public int Id { get; set; }
    public int FatherId { get; set; }
    [JsonIgnore]
   public int AlternateUoM { get; set; }
    public double AltQty { get; set; }
    public double BaseQty { get; set; }
    [JsonIgnore]
    public OUGP? Father { get; set; }
    [JsonIgnore]
    public OUOM? AlternateUnit { get; set; }
}
