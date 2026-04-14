using DemoAPI.Core.DTOs;
using DemoAPI.Core.Helpers;
using DemoAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams param)
        {
            try
            {
                return Ok(await _service.GetAllAsync(param));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Data = null
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Validation failed",
                        Data = string.Join(", ",
                            ModelState.Values.SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage))
                    });
                }

                await _service.CreateAsync(dto);
                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Product created",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Data = null
                });
            }          
        }
    }
}