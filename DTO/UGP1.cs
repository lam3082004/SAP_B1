using System;
using item_management.DTO;
using item_management.Models;
namespace item_management.DTO
{
    public class UGP1Dto
    {
        public int Id { get; set; }
        public int FatherId { get; set; }
        public int AlternateUoM { get; set; }
        public double AltQty { get; set; }
        public double BaseQty { get; set; }
        // public OUGP? Father { get; set; }
        // public OUOM? AlternateUnit { get; set; }
    }
}
// {
//   "id": 12,
//   "fatherId": 5,
//   "alternateUoM": 4,
//   "altQty": 1,
//   "baseQty": 1000
// }