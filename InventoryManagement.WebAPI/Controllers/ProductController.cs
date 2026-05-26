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

    public class ProductController : BaseController
    {
        private readonly IConfiguration _configuration;

        public ProductController(IServiceProvider serviceProvider, IOptions<SectionConfiguration> configuration, IConfiguration configurationSettings)
                : base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }

        [HttpGet]
        public IActionResult GetListProduct([FromQuery] QueryFilter filter)
        {
            var result = _ProductService.GetListProduct(filter);

            if (!result.stateOperation)
                return StatusCode(500, result);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _ProductService.GetProductById(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (result.Result == null)
                return NotFound(result);

            return Ok(result.Result);
        }

        [HttpPost("PostProduct")]
        public IActionResult PostProduct([FromBody] ProductManagerDto product)
        {
            var result = _ProductService.PostProduct(product);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(new { StateOperation = true, Result = true, Message = "Producto creado correctamente" });
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductManagerDto product)
        {
            var result = _ProductService.UpdateProduct(product);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _ProductService.DeleteProduct(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return NotFound(result);

            return Ok(result);
        }
    }
}