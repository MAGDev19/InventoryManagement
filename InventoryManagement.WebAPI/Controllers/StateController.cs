using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InventoryManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : BaseController
    {
        public StateController(IServiceProvider sp, IOptions<SectionConfiguration> config)
            : base(sp, config) { }
        [HttpGet("GetStates")]
        public IActionResult GetStates()
        {
            var result = _StateService.GetStates();

            if (!result.stateOperation)
                return StatusCode(500, result);

            return Ok(result.Result);
        }


        [HttpGet("GetState/{id}")]
        public IActionResult GetStateById(int id)
        {
            var result = _StateService.GetStateById(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (result.Result == null)
                return NotFound(result);

            return Ok(result.Result);
        }

        [HttpPost("PostState")]
        public IActionResult CreateState([FromBody] StateManagementDto state)
        {
            var result = _StateService.CreateState(state);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateState/{id}")]
        public IActionResult UpdateState(int id, [FromBody] StateManagementDto state)
        {
            var result = _StateService.UpdateState(id, state);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("DeleteState/{id}")]
        public IActionResult DeleteState(int id)
        {
            var result = _StateService.DeleteState(id);

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (!result.Result)
                return BadRequest(result);

            return Ok(new
            {
                StateOperation = true,
                Result = true,
                Message = "Estado eliminado correctamente"
            });
        }
    }
}
