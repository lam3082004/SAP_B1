using System;
using Microsoft.AspNetCore.Mvc;
using item_management.Data;
using item_management.DTO;
using item_management.Models;
using item_management.Service;
namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OUOMController(IOUOM_Service service) : ControllerBase
    {
        private readonly IOUOM_Service _service = service;

        [HttpGet("GetOUOMByCode/{code}")]
        public async Task<IActionResult> GetOUOMByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Invalid OUOM code");
            }

            try
            {
                var ouom = await _service.GetOUOMByCodeAsync(code);
                if (ouom == null)
                {
                    return NotFound("OUOM not found");
                }
                return Ok(new
                {
                    Message = "OUOM retrieved successfully",
                    Data = ouom
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateOUOM")]
        public async Task<IActionResult> CreateOUOM([FromBody] OUOMDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Code) || string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest("Invalid OUOM data");
            }

            try
            {
                var createdOUOM = await _service.CreateOUOMAsync(dto);
                if (createdOUOM == null)
                {
                    return BadRequest("Failed to create OUOM");
                }
                return CreatedAtAction(nameof(GetOUOMByCode), new { code = createdOUOM.Code }, new
                {
                    Message = "OUOM created successfully",
                    Data = createdOUOM
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOUOM")]
        public async Task<IActionResult> UpdateOUOM([FromBody] OUOMDto dto)
        {
            if (dto == null || dto.Id <= 0 || string.IsNullOrEmpty(dto.Code) || string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest("Invalid OUOM data");
            }

            try
            {
                var updatedOUOM = await _service.UpdateOUOMAsync(dto);
                if (updatedOUOM == null)
                {
                    return NotFound("OUOM not found or failed to update");
                }
                return Ok(new
                {
                    Message = "OUOM updated successfully",
                    Data = updatedOUOM
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOUOM/{id}")]
        public async Task<IActionResult> DeleteOUOM(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid OUOM ID");
            }

            try
            {
                var deletedOUOM = await _service.DeleteOUOMAsync(id);
                if (deletedOUOM == null)
                {
                    return NotFound("OUOM not found or failed to delete");
                }
                return Ok(new
                {
                    Message = "OUOM deleted successfully",
                    Data = deletedOUOM
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

