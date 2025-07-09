using item_management.Data;
using item_management.Models;
using System.Collections.Generic;
using item_management.DTO;
using Microsoft.EntityFrameworkCore;

namespace item_management.Repository
{
    public interface IOITM_Repository
    {
        Task<OITM?> GetItemByIdAsync(int id); // Optional: If you want to get an item by ID
        Task<OITM?> GetItemCodeAsync(string itemCode);
        Task<OITMDto> CreateOITMAsync(OITMDto dto);
        Task<OITMDto?> UpdateOITMAsync(OITMDto dto);
        Task<OITMDto?> DeleteOITMAsync(int id); // Assuming you want to delete an item by ID
    }
    public class OITM_Repository(ApplicationDbContext context) : IOITM_Repository
    {
        // Implementation of the methods defined in the interface
        private readonly ApplicationDbContext _context = context;

        public async Task<OITM?> GetItemByIdAsync(int id)
        {
            return await _context.OITM
                .Include(x => x.OITW) // Eager load OITW collection
                .FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task<OITM?> GetItemCodeAsync(string itemCode)
        {
            return await _context.OITM
                .Include(x => x.OITW) // Eager load OITW collection
                .FirstOrDefaultAsync(item => item.ItemCode == itemCode);
        }
        public async Task<OITMDto> CreateOITMAsync(OITMDto dto)
        {
            var item = new OITM
            {
                ItemCode = dto.ItemCode,
                ItemName = dto.ItemName,
                ItemGroup = dto.ItemGroup,
                OUGPId = dto.OUGPId,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            _context.OITM.Add(item);
            await _context.SaveChangesAsync();

            return new OITMDto
            {
                Id = item.Id,
                ItemCode = item.ItemCode,
                ItemName = item.ItemName,
                ItemGroup = item.ItemGroup,
                OUGPId = item.OUGPId,
                Price = item.Price,
                IsActive = item.IsActive
            };
        }
        public async Task<OITMDto?> UpdateOITMAsync(OITMDto dto)
        {
            var item = await _context.OITM.FindAsync(dto.Id);
            if (item == null)
            {
                return null; // Item not found
            }

            item.ItemCode = dto.ItemCode;
            item.ItemName = dto.ItemName;
            item.ItemGroup = dto.ItemGroup;
            item.OUGPId = dto.OUGPId;
            item.Price = dto.Price;
            item.IsActive = dto.IsActive;

            _context.OITM.Update(item);
            await _context.SaveChangesAsync();

            return new OITMDto
            {
                Id = item.Id,
                ItemCode = item.ItemCode,
                ItemName = item.ItemName,
                ItemGroup = item.ItemGroup,
                OUGPId = item.OUGPId,
                Price = item.Price,
                IsActive = item.IsActive
            };
        }
        public async Task<OITMDto?> DeleteOITMAsync(int id)
        {
            var item = await _context.OITM.FindAsync(id);
            if (item == null)
            {
                return null; // Item not found
            }

            _context.OITM.Remove(item);
            await _context.SaveChangesAsync();

            return new OITMDto
            {
                Id = item.Id,
                ItemCode = item.ItemCode,
                ItemName = item.ItemName,
                ItemGroup = item.ItemGroup,
                OUGPId = item.OUGPId,
                Price = item.Price,
                IsActive = item.IsActive
            };
        }
    }
}
