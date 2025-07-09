using System;
using System.Threading.Tasks;
using item_management.DTO;
using item_management.Service;
using Microsoft.AspNetCore.Mvc;

namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OITWController(IOITW_Service service) : ControllerBase
    {
        private readonly IOITW_Service _service = service;

        [HttpGet("GetWarehouseById/{id}")]
        public async Task<IActionResult> GetWarehouseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid warehouse ID");
            }

            try
            {
                var warehouse = await _service.GetWarehouseByIdAsync(id);
                if (warehouse == null)
                {
                    return NotFound("Warehouse not found");
                }
                return Ok(new
                {
                    Message = "Warehouse retrieved successfully",
                    Data = warehouse
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateOITW")]
        public async Task<IActionResult> CreateOITW([FromBody] OITWDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Warehouse data is null");
            }

            try
            {
                var createdWarehouse = await _service.CreateOITWAsync(dto);
                return CreatedAtAction(
                    nameof(GetWarehouseById),
                    new { id = createdWarehouse.Id }, // Assuming OITWDto has an Id property
                    new
                    {
                        Message = "Warehouse created successfully",
                        Data = createdWarehouse
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOITW")]
        public async Task<IActionResult> UpdateOITW([FromBody] OITWDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Warehouse data is null");
            }
            if (dto.Id <= 0)
            {
                return BadRequest("Invalid warehouse ID");
            }
            try
            {
                var updatedWarehouse = await _service.UpdateOITWAsync(dto);
                if (updatedWarehouse == null)
                {
                    return NotFound("Warehouse not found");
                }
                return Ok(new
                {
                    Message = "Warehouse updated successfully",
                    Data = updatedWarehouse
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOITW/{id}")]
        public async Task<IActionResult> DeleteOITW(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid warehouse ID");
            }

            try
            {
                var deletedWarehouse = await _service.DeleteOITWAsync(id);
                if (deletedWarehouse == null)
                {
                    return NotFound("Warehouse not found");
                }
                return Ok(new
                {
                    Message = "Warehouse deleted successfully",
                    Data = deletedWarehouse
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

