using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace item_management.Models;

public class OWHS
{
    public int Id { get; set; }
    public string WhsCode { get; set; } = string.Empty;
    public string WhsName { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<OITW> OITW { get; set; } = new List<OITW>();
}