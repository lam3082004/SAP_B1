using System;
using System.Threading.Tasks;
using item_management.DTO;
using item_management.Service;
using Microsoft.AspNetCore.Mvc;

namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UGP1Controller(IUGP1_Service service) : ControllerBase
    {
        private readonly IUGP1_Service _service = service;

        [HttpGet("GetUGP1ById/{id}")]
        public async Task<IActionResult> GetUGP1ById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid UGP1 ID");
            }

            try
            {
                var ugp1 = await _service.GetUGP1ByIdAsync(id);
                if (ugp1 == null)
                {
                    return NotFound("UGP1 not found");
                }
                return Ok(new
                {
                    Message = "UGP1 retrieved successfully",
                    Data = ugp1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving UGP1 with ID {id}: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateUGP1")]
        public async Task<IActionResult> CreateUGP1([FromBody] UGP1Dto dto)
        {
            if (dto == null || dto.FatherId <= 0 || dto.AltQty <= 0 || dto.BaseQty <= 0)
            {
                return BadRequest("Invalid UGP1 data");
            }

            try
            {
                var createdUGP1 = await _service.CreateUGP1Async(dto);
                if (createdUGP1 == null)
                {
                    return BadRequest("Failed to create UGP1");
                }
                return CreatedAtAction(nameof(GetUGP1ById), new { id = createdUGP1.Id }, new
                {
                    Message = "UGP1 created successfully",
                    Data = createdUGP1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating UGP1: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateUGP1")]
        public async Task<IActionResult> UpdateUGP1([FromBody] UGP1Dto dto)
        {
            if (dto == null || dto.Id <= 0 || dto.FatherId <= 0 || dto.AltQty <= 0 || dto.BaseQty <= 0)
            {
                return BadRequest("Invalid UGP1 data");
            }

            try
            {
                var updatedUGP1 = await _service.UpdateUGP1Async(dto);
                if (updatedUGP1 == null)
                {
                    return NotFound("UGP1 not found for update");
                }
                return Ok(new
                {
                    Message = "UGP1 updated successfully",
                    Data = updatedUGP1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating UGP1 with ID {dto.Id}: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteUGP1/{id}")]
        public async Task<IActionResult> DeleteUGP1(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid UGP1 ID");
            }

            try
            {
                var deletedUGP1 = await _service.DeleteUGP1Async(id);
                if (deletedUGP1 == null)
                {
                    return NotFound("UGP1 not found for deletion");
                }
                return Ok(new
                {
                    Message = "UGP1 deleted successfully",
                    Data = deletedUGP1
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting UGP1 with ID {id}: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

