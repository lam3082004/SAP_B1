using System;
using Microsoft.AspNetCore.Mvc;
using item_management.Data;
using item_management.Models;
using item_management.DTO;
using item_management.Service;

namespace item_management.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OITMController(IOITM_Service service) : ControllerBase
    {
        private readonly IOITM_Service _service = service;
        [HttpGet("GetItemById/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid item ID");
            }

            try
            {
                var item = await _service.GetItemByIdAsync(id);
                if (item == null)
                {
                    return NotFound("Item not found");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetItemCode")]
        public async Task<IActionResult> GetItemCode(string itemCode)
        {
            try
            {
                var result = await _service.GetItemCodeAsync(itemCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateOITM")]
        public async Task<IActionResult> CreateOITM([FromBody] OITMDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Item data is null");
            }

            try
            {
                var createdItem = await _service.CreateOITMAsync(dto);
                return StatusCode(201, "Created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOITM")]
        public async Task<IActionResult> UpdateOITM([FromBody] OITMDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("Invalid item data");
            }

            try
            {
                var updatedItem = await _service.UpdateOITMAsync(dto);
                if (updatedItem == null)
                {
                    return NotFound("Item not found");
                }
                return Ok(new
                {
                    Message = "Update Successful",
                    Item = updatedItem
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOITM/{id}")]
        public async Task<IActionResult> DeleteOITM(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid item ID");
            }

            try
            {
                var deletedItem = await _service.DeleteOITMAsync(id);
                if (deletedItem == null)
                {
                    return NotFound("Item not found");
                }
                return Ok(new
                {
                    Message = "Delete Successful",
                    Item = deletedItem
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
