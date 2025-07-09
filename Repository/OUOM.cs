using item_management.Data;
using item_management.DTO;
using item_management.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace item_management.Repository
{
    public interface IOUOM_Repository
    {
        Task<OUOM?> GetOUOMByCodeAsync(string code);
        Task<OUOMDto?> CreateOUOMAsync(OUOMDto dto);
        Task<OUOMDto?> UpdateOUOMAsync(OUOMDto dto);
        Task<OUOMDto?> DeleteOUOMAsync(int id);
    }
    public class OUOM_Repository : IOUOM_Repository
    {
        private readonly ApplicationDbContext _context;
        public OUOM_Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OUOM?> GetOUOMByCodeAsync(string code)
        {
            return await _context.OUOM
                .FirstOrDefaultAsync(ouom => ouom.Code == code);
        }
        public async Task<OUOMDto?> CreateOUOMAsync(OUOMDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var newOUOM = new OUOM
            {
                Code = dto.Code,
                Name = dto.Name
            };

            _context.OUOM.Add(newOUOM);
            await _context.SaveChangesAsync();

            return new OUOMDto
            {
                Id = newOUOM.Id,
                Code = newOUOM.Code,
                Name = newOUOM.Name
            };
        }
        public async Task<OUOMDto?> UpdateOUOMAsync(OUOMDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var existingOUOM = await _context.OUOM.FindAsync(dto.Id);
            if (existingOUOM == null)
            {
                return null;
            }

            existingOUOM.Code = dto.Code;
            existingOUOM.Name = dto.Name;

            _context.OUOM.Update(existingOUOM);
            await _context.SaveChangesAsync();

            return new OUOMDto
            {
                Id = existingOUOM.Id,
                Code = existingOUOM.Code,
                Name = existingOUOM.Name
            };
        }
        public async Task<OUOMDto?> DeleteOUOMAsync(int id)
        {
            var ouom = await _context.OUOM.FindAsync(id);
            if (ouom == null)
            {
                return null; // OUOM not found
            }

            _context.OUOM.Remove(ouom);
            await _context.SaveChangesAsync();

            return new OUOMDto
            {
                Id = ouom.Id,
                Code = ouom.Code,
                Name = ouom.Name
            };
        }
    }
}
