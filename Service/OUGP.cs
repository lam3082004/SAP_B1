using System;
using item_management.Models;
using item_management.Repository;
using item_management.DTO;
using item_management.Data;
namespace item_management.Service
{
    public interface IOUGP_Service
    {
        Task<OUGP?> GetOUGPByCodeAsync(string code);
        Task<OUGPDto> CreateOUGPAsync(OUGPDto dto);
        Task<OUGPDto?> UpdateOUGPAsync(OUGPDto dto); // Assuming you want to update an OUGP
        Task<OUGPDto?> DeleteOUGPAsync(int id); // Assuming you want
    }
    public class OUGP_Service(IOUGP_Repository repository) : IOUGP_Service
    {
        private readonly IOUGP_Repository _repository = repository;
        public async Task<OUGP?> GetOUGPByCodeAsync(string code)
        {
            return await _repository.GetOUGPByCodeAsync(code);
        }
        public async Task<OUGPDto> CreateOUGPAsync(OUGPDto dto)
        {
            return await _repository.CreateOUGPAsync(dto);
        }
        public async Task<OUGPDto?> UpdateOUGPAsync(OUGPDto dto)
        {
            return await _repository.UpdateOUGPAsync(dto);
        }
        public async Task<OUGPDto?> DeleteOUGPAsync(int id)
        {
            return await _repository.DeleteOUGPAsync(id);
        }
    }
}
