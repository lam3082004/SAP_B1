using System;
using item_management.Models;
using item_management.Repository;
using item_management.DTO;
using Microsoft.AspNetCore.Mvc;
namespace item_management.Service
{
    public interface IOITM_Service
    {
        Task<OITM?> GetItemByIdAsync(int id);
        Task<OITM?> GetItemCodeAsync(string itemCode);
        Task<OITMDto> CreateOITMAsync(OITMDto dto);
        Task<OITMDto?> UpdateOITMAsync(OITMDto dto);
        Task<OITMDto?> DeleteOITMAsync(int id); // Assuming you want to delete an item by ID
    }
    public class OITM_Service(IOITM_Repository repository) : IOITM_Service
    {
        private readonly IOITM_Repository _repository = repository;

        public Task<OITM?> GetItemByIdAsync(int id)
        {
            // Assuming the repository has a method to get an item by ID
            return _repository.GetItemByIdAsync(id);
        }
        public Task<OITM?> GetItemCodeAsync(string itemCode)
        {
            return _repository.GetItemCodeAsync(itemCode);
        }
        public Task<OITMDto> CreateOITMAsync(OITMDto dto)
        {
            return _repository.CreateOITMAsync(dto);
        }
        public Task<OITMDto?> UpdateOITMAsync(OITMDto dto)
        {
            // Assuming the repository has an Update method
            return _repository.UpdateOITMAsync(dto);
        }
        public Task<OITMDto?> DeleteOITMAsync(int id)
        {
            // Assuming the repository has a Delete method
            return _repository.DeleteOITMAsync(id);
        }
        // Implement other methods similarly
    }
}
