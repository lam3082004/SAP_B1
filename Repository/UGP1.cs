using System;
using System.Threading.Tasks;
using item_management.Data;
using item_management.DTO;
using item_management.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace item_management.Repository
{
    public interface IUGP1Repository
    {
        Task<UGP1?> GetUGP1ByIdAsync(int id);
        Task<UGP1Dto> CreateUGP1Async(UGP1Dto dto);
        Task<UGP1Dto?> UpdateUGP1Async(UGP1Dto dto); // Assuming you want to update a UGP1
        Task<UGP1Dto?> DeleteUGP1Async(int id); // Assuming you
    }
    public class UGP1Repository(ApplicationDbContext context) : IUGP1Repository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<UGP1?> GetUGP1ByIdAsync(int id)
        {
            return await _context.UGP1.FindAsync(id);
        }
        public async Task<UGP1Dto> CreateUGP1Async(UGP1Dto dto)
        {
            var existingUGP1 = await _context.UGP1
                .FirstOrDefaultAsync(ugp1 => ugp1.FatherId == dto.FatherId && ugp1.AlternateUoM == dto.AlternateUoM);
            if (existingUGP1 != null)
                throw new Exception("UGP1 with this FatherId and AlternateUoM already exists.");

            var ugp1 = new UGP1
            {
                FatherId = dto.FatherId,
                AlternateUoM = dto.AlternateUoM,
                AltQty = dto.AltQty,
                BaseQty = dto.BaseQty
            };

            _context.UGP1.Add(ugp1);
            await _context.SaveChangesAsync();

            return new UGP1Dto
            {
                Id = ugp1.Id,
                FatherId = ugp1.FatherId,
                AlternateUoM = ugp1.AlternateUoM,
                AltQty = ugp1.AltQty,
                BaseQty = ugp1.BaseQty
            };
            // {
            //     "id": 12,
            //     "fatherId": 5,
            //     "alternateUoM": 6,
            //     "altQty": 1,
            //     "baseQty": 5550
            // }
        }
        public async Task<UGP1Dto?> UpdateUGP1Async(UGP1Dto dto)
        {
            var ugp1 = await _context.UGP1.FindAsync(dto.Id);
            if (ugp1 == null)
                return null;

            ugp1.FatherId = dto.FatherId;
            ugp1.AlternateUoM = dto.AlternateUoM;
            ugp1.AltQty = dto.AltQty;
            ugp1.BaseQty = dto.BaseQty;

            _context.UGP1.Update(ugp1);
            await _context.SaveChangesAsync();

            return new UGP1Dto
            {
                Id = ugp1.Id,
                FatherId = ugp1.FatherId,
                AlternateUoM = ugp1.AlternateUoM,
                AltQty = ugp1.AltQty,
                BaseQty = ugp1.BaseQty
            };
        }
        public async Task<UGP1Dto?> DeleteUGP1Async(int id)
        {
            var ugp1 = await _context.UGP1.FindAsync(id);
            if (ugp1 == null)
                return null;

            _context.UGP1.Remove(ugp1);
            await _context.SaveChangesAsync();

            return new UGP1Dto
            {
                Id = ugp1.Id,
                FatherId = ugp1.FatherId,
                AlternateUoM = ugp1.AlternateUoM,
                AltQty = ugp1.AltQty,
                BaseQty = ugp1.BaseQty
            };
        }
    }
}

