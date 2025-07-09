using System;
using System.Threading.Tasks;
using item_management.Data;
using item_management.DTO;
using item_management.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace item_management.Repository
{
    public interface IOUGP_Repository
    {
        Task<OUGP?> GetOUGPByCodeAsync(string code);
        Task<OUGPDto> CreateOUGPAsync(OUGPDto dto);
        Task<OUGPDto?> UpdateOUGPAsync(OUGPDto dto); // Assuming you want to update an OUGP
        Task<OUGPDto?> DeleteOUGPAsync(int id); // Assuming you want
    }
    public class OUGP_Repository(ApplicationDbContext context) : IOUGP_Repository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<OUGP?> GetOUGPByCodeAsync(string code)
        {
            return await _context.OUGP
                .Include(x => x.UGP1)
                .Select(UGP1 => new OUGP
                {
                    Id = UGP1.Id,
                    Code = UGP1.Code,
                    Name = UGP1.Name,
                    BaseUom = UGP1.BaseUom,
                    // BaseUnit = UGP1.BaseUnit,
                    UGP1 = UGP1.UGP1
                })
                .FirstOrDefaultAsync(ougp => ougp.Code == code);
        }
        public async Task<OUGPDto> CreateOUGPAsync(OUGPDto dto)
        {
            var existingOUGP = await _context.OUGP
                .FirstOrDefaultAsync(ougp => ougp.Code == dto.Code);
            if (existingOUGP != null)
                throw new Exception("OUGP with this code already exists.");

            var ougp = new OUGP
            {
                Code = dto.Code,
                Name = dto.Name,
                BaseUom = dto.BaseUom
            };

            _context.OUGP.Add(ougp);
            await _context.SaveChangesAsync();

            return new OUGPDto
            {
                Code = ougp.Code,
                Name = ougp.Name,
                BaseUom = ougp.BaseUom
            };
        }
        public async Task<OUGPDto?> UpdateOUGPAsync(OUGPDto dto)
        {
            var ougp = await _context.OUGP
                .FirstOrDefaultAsync(ougp => ougp.Id == dto.Id);
            if (ougp == null)
                return null;

            ougp.Code = dto.Code;
            ougp.Name = dto.Name;
            ougp.BaseUom = dto.BaseUom;

            _context.OUGP.Update(ougp);
            await _context.SaveChangesAsync();

            return new OUGPDto
            {
                Id = ougp.Id,
                Code = ougp.Code,
                Name = ougp.Name,
                BaseUom = ougp.BaseUom
            };
        }
        public async Task<OUGPDto?> DeleteOUGPAsync(int id)
        {
            var ougp = await _context.OUGP
                .FirstOrDefaultAsync(ougp => ougp.Id == id);
            if (ougp == null)
                return null;

            _context.OUGP.Remove(ougp);
            await _context.SaveChangesAsync();

            return new OUGPDto
            {
                Id = ougp.Id,
                Code = ougp.Code,
                Name = ougp.Name,
                BaseUom = ougp.BaseUom
            };
        }
    }
}

