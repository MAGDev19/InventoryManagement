using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.Dto;

namespace InventoryManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]

    public class CategoryController : BaseController
    {
        private readonly IConfiguration _configuration;

        public CategoryController(IServiceProvider serviceProvider, IOptions<SectionConfiguration> configuration, IConfiguration configurationSettings)
                : base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }

        [HttpGet]
        public IActionResult GetListCategory([FromQuery] QueryFilter filter)
        {
            var result = _CategoryService.GetListCategory(filter);

            if (!result.stateOperation)
                return StatusCode(500, result);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _CategoryService.GetCategoryById(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (result.Result == null)
                return NotFound(result);

            return Ok(result.Result);
        }

        [HttpPost("PostCategory")]
        public IActionResult PostCategory([FromBody] CategoryManagementDto category)
        {
            var result = _CategoryService.PostCategory(category);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(new { StateOperation = true, Result = true, Message = "Categoría creada correctamente" });
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] CategoryManagementDto category)
        {
            var result = _CategoryService.UpdateCategory(category);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _CategoryService.DeleteCategory(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return NotFound(result);

            return Ok(result);
        }
    }
}