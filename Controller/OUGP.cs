using System;
using System.Threading.Tasks;
using item_management.DTO;
using item_management.Service;
using Microsoft.AspNetCore.Mvc;

namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OUGPController(IOUGP_Service service) : ControllerBase
    {
        private readonly IOUGP_Service _service = service;

        [HttpGet("GetOUGPById/{code}")]
        public async Task<IActionResult> GetOUGPById(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Invalid OUGP code");
            }

            try
            {
                var ougp = await _service.GetOUGPByCodeAsync(code);
                if (ougp == null)
                {
                    return NotFound("OUGP not found");
                }
                return Ok(new
                {
                    Message = "OUGP retrieved successfully",
                    Data = ougp
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateOUGP")]
        public async Task<IActionResult> CreateOUGP([FromBody] OUGPDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Code) || string.IsNullOrEmpty(dto.Name) || dto.BaseUom <= 0)
            {
                return BadRequest("Invalid OUGP data");
            }
            try
            {
                var createdOUGP = await _service.CreateOUGPAsync(dto);
                if (createdOUGP == null)
                {
                    return BadRequest("Failed to create OUGP");
                }
                return CreatedAtAction(nameof(GetOUGPById), new { code = createdOUGP.Code }, new
                {
                    Message = "OUGP created successfully",
                    Data = createdOUGP
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOUGP")]
        public async Task<IActionResult> UpdateOUGP([FromBody] OUGPDto dto)
        {
            if (dto == null || dto.Id <= 0 || string.IsNullOrEmpty(dto.Code) || string.IsNullOrEmpty(dto.Name) || dto.BaseUom <= 0)
            {
                return BadRequest("Invalid OUGP data");
            }
            try
            {
                var updatedOUGP = await _service.UpdateOUGPAsync(dto);
                if (updatedOUGP == null)
                {
                    return NotFound("OUGP not found for update");
                }
                return Ok(new
                {
                    Message = "OUGP updated successfully",
                    Data = updatedOUGP
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOUGP/{id}")]
        public async Task<IActionResult> DeleteOUGP(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid OUGP ID");
            }
            try
            {
                var deletedOUGP = await _service.DeleteOUGPAsync(id);
                if (deletedOUGP == null)
                {
                    return NotFound("OUGP not found for deletion");
                }
                return Ok(new
                {
                    Message = "OUGP deleted successfully",
                    Data = deletedOUGP
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

