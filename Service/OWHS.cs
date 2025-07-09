using System;
using item_management.Models;
using item_management.Repository;
using item_management.DTO;
using item_management.Data;
namespace item_management.Service
{
    public interface IOWHS_Service
    {
        Task<OWHS?> GetWarehouseByIdAsync(int id);
        Task<OWHSDto?> CreateWhsAsync(OWHSDto dto);
        Task<OWHSDto?> UpdateWhsAsync(OWHSDto dto);
        Task<OWHSDto?> DeleteWhsAsync(string WhsCode); // Assuming you want to delete a warehouse by code
    }
    public class OWHS_Service(IOWHS_Repository repository) : IOWHS_Service
    {
        private readonly IOWHS_Repository _repository = repository;

        public Task<OWHS?> GetWarehouseByIdAsync(int id)
        {
            return _repository.GetWhsByIdAsync(id);
        }
        public async Task<OWHSDto?> CreateWhsAsync(OWHSDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var newWhs = new OWHSDto
            {
                WhsCode = dto.WhsCode,
                WhsName = dto.WhsName
            };

            var createdWhs = await _repository.CreateWhsAsync(newWhs);
            if (createdWhs == null)
            {
                return null;
            }

            return new OWHSDto
            {
                Id = createdWhs.Id,
                WhsCode = createdWhs.WhsCode,
                WhsName = createdWhs.WhsName
            };
        }
        public async Task<OWHSDto?> UpdateWhsAsync(OWHSDto dto)
        {
            return await _repository.UpdateWhsAsync(dto);
        }
        public async Task<OWHSDto?> DeleteWhsAsync(string WhsCode)
        {
            return await _repository.DeleteWhsAsync(WhsCode);
        }
        // Implement other methods similarly if needed
    }   
        
}
