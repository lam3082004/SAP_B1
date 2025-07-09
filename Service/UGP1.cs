using System;
using item_management.Models;
using item_management.DTO;
using item_management.Repository;
using System.Threading.Tasks;
namespace item_management.Service
{
    public interface IUGP1_Service
    {
        Task<UGP1?> GetUGP1ByIdAsync(int id);
        Task<UGP1Dto> CreateUGP1Async(UGP1Dto dto);
        Task<UGP1Dto?> UpdateUGP1Async(UGP1Dto dto); // Assuming you want to update a UGP1
        Task<UGP1Dto?> DeleteUGP1Async(int id); // Assuming you
    }
    public class UGP1_Service(IUGP1Repository repository) : IUGP1_Service
    {
        private readonly IUGP1Repository _repository = repository;
        public async Task<UGP1?> GetUGP1ByIdAsync(int id)
        {
            return await _repository.GetUGP1ByIdAsync(id);
        }
        public async Task<UGP1Dto> CreateUGP1Async(UGP1Dto dto)
        {
            return await _repository.CreateUGP1Async(dto);
        }
        public async Task<UGP1Dto?> UpdateUGP1Async(UGP1Dto dto)
        {
            return await _repository.UpdateUGP1Async(dto);
        }
        public async Task<UGP1Dto?> DeleteUGP1Async(int id)
        {
            return await _repository.DeleteUGP1Async(id);
        }
    }
}
