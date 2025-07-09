using System;
using item_management.Models;
using item_management.Repository;
using item_management.DTO;
using item_management.Data;
namespace item_management.Service
{
    public interface IOITW_Service
    {
        Task<OITW?> GetWarehouseByIdAsync(int id);
        Task<OITWDto> CreateOITWAsync(OITWDto dto);
        Task<OITWDto?> UpdateOITWAsync(OITWDto dto);
        Task<OITWDto?> DeleteOITWAsync(int id); // Assuming you want to delete a warehouse by ID
    }
    public class OITW_Service(IOITW_Repository repository) : IOITW_Service
    {
        private readonly IOITW_Repository _repository = repository;

        public Task<OITW?> GetWarehouseByIdAsync(int id)
        {
            return _repository.GetWarehouseByIdAsync(id);
        }
        public async Task<OITWDto> CreateOITWAsync(OITWDto dto)
        {
            return await _repository.CreateOITWAsync(dto);
        }
        public async Task<OITWDto?> UpdateOITWAsync(OITWDto dto)
        {
            return await _repository.UpdateOITWAsync(dto);
        }
        public async Task<OITWDto?> DeleteOITWAsync(int id)
        {
            return await _repository.DeleteOITWAsync(id);
        }
    }
}
