using InventoryManagement.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InventoryManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class InventoryReportController
        : BaseController
    {
        private readonly IConfiguration _configuration;

        public InventoryReportController(IServiceProvider serviceProvider,IOptions<SectionConfiguration> configuration,IConfiguration configurationSettings): base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }

        [HttpGet("summary")]
        public IActionResult GetInventorySummary()
        {
            var result = _InventoryReportService.GetInventorySummary();

            if (!result.stateOperation)
                return StatusCode(500, result);

            if (result.Result == null)
                return NotFound(result);

            return Ok(result.Result);
        }
    }
}