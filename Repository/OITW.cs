using System;
using System.Threading.Tasks;
using item_management.Data;
using item_management.DTO;
using item_management.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace item_management.Repository
{
    public interface IOITW_Repository
    {
        Task<OITW?> GetWarehouseByIdAsync(int id);
        Task<OITWDto> CreateOITWAsync(OITWDto dto);
        Task<OITWDto?> UpdateOITWAsync(OITWDto dto);
        Task<OITWDto?> DeleteOITWAsync(int id); // Assuming you want to delete a warehouse by its code
    }
    public class OITW_Repository(ApplicationDbContext context) : IOITW_Repository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<OITW?> GetWarehouseByIdAsync(int id)
        {
            return await _context.OITW.FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<OITWDto> CreateOITWAsync(OITWDto dto)
        {
            var warehouseExists = await _context.OWHS.AnyAsync(w => w.WhsCode == dto.WarehouseCode);
            if (!warehouseExists)
                throw new Exception("WarehouseCode does not exist");
            var duplicate = await _context.OITW.AnyAsync(w => w.ItemId == dto.ItemId && w.WarehouseCode == dto.WarehouseCode);
            if (duplicate)
                throw new Exception("This item already exists in the warehouse.");
            var warehouse = new OITW
            {
                ItemId = dto.ItemId,
                WarehouseCode = dto.WarehouseCode,
                QuantityOnHand = dto.QuantityOnHand
            };

            _context.OITW.Add(warehouse);
            await _context.SaveChangesAsync();

            return new OITWDto
            {
                ItemId = warehouse.ItemId,
                WarehouseCode = warehouse.WarehouseCode,
                QuantityOnHand = warehouse.QuantityOnHand
            };
        }
        public async Task<OITWDto?> UpdateOITWAsync(OITWDto dto)
        {
            var warehouse = await _context.OITW.FirstOrDefaultAsync(w => w.Id == dto.Id);
            if (warehouse == null)
                return null;
            var warehouseExists = await _context.OWHS.AnyAsync(w => w.WhsCode == dto.WarehouseCode);
            if (!warehouseExists)
                throw new Exception("WarehouseCode does not exist");
            // var duplicate = await _context.OITW.AnyAsync(w => w.ItemId == dto.ItemId && w.WarehouseCode == dto.WarehouseCode && w.Id != dto.Id);
            // if (duplicate)
            //     throw new Exception("This item already exists in the warehouse.");
            warehouse.ItemId = dto.ItemId;
            warehouse.WarehouseCode = dto.WarehouseCode;
            warehouse.QuantityOnHand = dto.QuantityOnHand;
            _context.OITW.Update(warehouse);
            await _context.SaveChangesAsync();
            return new OITWDto
            {
                Id = warehouse.Id,
                ItemId = warehouse.ItemId,
                WarehouseCode = warehouse.WarehouseCode,
                QuantityOnHand = warehouse.QuantityOnHand
            };
        }
        public async Task<OITWDto?> DeleteOITWAsync(int id)
        {
            var warehouse = await _context.OITW.FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse == null)
                return null;
            _context.OITW.Remove(warehouse);
            await _context.SaveChangesAsync();
            return new OITWDto
            {
                Id = warehouse.Id,
                ItemId = warehouse.ItemId,
                WarehouseCode = warehouse.WarehouseCode,
                QuantityOnHand = warehouse.QuantityOnHand
            };
        }
          // {
          //   "id": 1,
          //   "itemId": 1,
          //   "warehouseCode": "WH-CT",
          //   "quantityOnHand": 2000
          // }
    }
}

