using System;
using item_management.Models;
using item_management.DTO;
using item_management.Repository;
using System.Threading.Tasks;
namespace item_management.Service
{
    public interface IOUOM_Service
    {
        Task<OUOM?> GetOUOMByCodeAsync(string code);
        Task<OUOMDto?> CreateOUOMAsync(OUOMDto dto);
        Task<OUOMDto?> UpdateOUOMAsync(OUOMDto dto);
        Task<OUOMDto?> DeleteOUOMAsync(int id); // Assuming you want to delete a OUOM by ID
    }
    public class OUOM_Service(IOUOM_Repository repository) : IOUOM_Service
    {
        private readonly IOUOM_Repository _repository = repository;

        public async Task<OUOM?> GetOUOMByCodeAsync(string code)
        {
            return await _repository.GetOUOMByCodeAsync(code);
        }
        public async Task<OUOMDto?> CreateOUOMAsync(OUOMDto dto)
        {
            return await _repository.CreateOUOMAsync(dto);
        }
        public async Task<OUOMDto?> UpdateOUOMAsync(OUOMDto dto)
        {
            return await _repository.UpdateOUOMAsync(dto);
        }
        public async Task<OUOMDto?> DeleteOUOMAsync(int id)
        {
            return await _repository.DeleteOUOMAsync(id);
        }
    }
}
