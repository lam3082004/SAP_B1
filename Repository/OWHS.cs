    using item_management.Data;
    using item_management.DTO;
    using item_management.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

namespace item_management.Repository
{
    public interface IOWHS_Repository
    {
        Task<OWHS?> GetWhsByIdAsync(int id);
        Task<OWHSDto?> CreateWhsAsync(OWHSDto dto);
        Task<OWHSDto?> UpdateWhsAsync(OWHSDto dto);
        Task<OWHSDto?> DeleteWhsAsync(string WhsCode); // Assuming you want
    }

    public class OWHS_Repository : IOWHS_Repository
    {
        private readonly ApplicationDbContext _context;

        public OWHS_Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OWHS?> GetWhsByIdAsync(int id)
        {
            return await _context.OWHS
                .Include(w => w.OITW) // Eager load OITW collection
                .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<OWHSDto?> CreateWhsAsync(OWHSDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var newWhs = new OWHS
            {
                WhsCode = dto.WhsCode,
                WhsName = dto.WhsName
            };

            _context.OWHS.Add(newWhs);
            await _context.SaveChangesAsync();

            return new OWHSDto
            {
                Id = newWhs.Id,
                WhsCode = newWhs.WhsCode,
                WhsName = newWhs.WhsName
            };
        }
        public async Task<OWHSDto?> UpdateWhsAsync(OWHSDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var existingWhs = await _context.OWHS.FindAsync(dto.Id);
            if (existingWhs == null)
            {
                return null;
            }

            existingWhs.WhsCode = dto.WhsCode;
            existingWhs.WhsName = dto.WhsName;

            _context.OWHS.Update(existingWhs);
            await _context.SaveChangesAsync();

            return new OWHSDto
            {
                Id = existingWhs.Id,
                WhsCode = existingWhs.WhsCode,
                WhsName = existingWhs.WhsName
            };
        }
        public async Task<OWHSDto?> DeleteWhsAsync(string WhsCode)
        {
            var whs = await _context.OWHS.FirstOrDefaultAsync(w => w.WhsCode == WhsCode);
            if (whs == null)
            {
                return null;
            }

            _context.OWHS.Remove(whs);
            await _context.SaveChangesAsync();

            return new OWHSDto
            {
                Id = whs.Id,
                WhsCode = whs.WhsCode,
                WhsName = whs.WhsName
            };
        }
    }
}