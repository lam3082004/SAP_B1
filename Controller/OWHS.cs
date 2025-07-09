using System;
using System.Threading.Tasks;
using item_management.DTO;
using item_management.Service;
using Microsoft.AspNetCore.Mvc;

namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OWHSController(IOWHS_Service service) : ControllerBase
    {
        private readonly IOWHS_Service _service = service;

        [HttpGet("GetWhs/{id}")]
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
                Console.WriteLine($"Lỗi khi lấy kho Id {id}: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateWhs")]
        public async Task<IActionResult> CreateWhs([FromBody] OWHSDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Warehouse data is null");
            }
            try
            {
                var createdWarehouse = await _service.CreateWhsAsync(dto);
                if (createdWarehouse == null)
                {
                    return BadRequest("Failed to create warehouse");
                }
                return CreatedAtAction(nameof(GetWarehouseById), new { id = createdWarehouse.Id }, new
                {
                    Message = "Warehouse created successfully",
                    Data = createdWarehouse
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo kho: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateWhs")]
        public async Task<IActionResult> UpdateWhs([FromBody] OWHSDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Warehouse data is null");
            }

            try
            {
                var updatedWarehouse = await _service.UpdateWhsAsync(dto);
                if (updatedWarehouse == null)
                {
                    return NotFound("Warehouse not found for update");
                }
                return Ok(new
                {
                    Message = "Warehouse updated successfully",
                    Data = updatedWarehouse
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật kho: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteWhs/{whsCode}")]
        public async Task<IActionResult> DeleteWhs(string whsCode)
        {
            if (string.IsNullOrEmpty(whsCode))
            {
                return BadRequest("Warehouse code is null or empty");
            }
            try
            {
                var deletedWarehouse = await _service.DeleteWhsAsync(whsCode);
                if (deletedWarehouse == null)
                {
                    return NotFound("Warehouse not found for deletion");
                }
                return Ok(new
                {
                    Message = "Warehouse deleted successfully",
                    Data = deletedWarehouse
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa kho: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
              // Add other methods as needed
    }
}

