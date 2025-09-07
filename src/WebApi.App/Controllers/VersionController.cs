using Microsoft.AspNetCore.Mvc;
using WebApi.Library;

namespace WebApi.App.Controllers
{
    [ApiController]
    [Route("api/version")]
    public class VersionController : ControllerBase
    {
        private readonly VersionService _versionService;
        private readonly ILogger<VersionController> _logger;

        public VersionController(ILogger<VersionController> logger)
        {
            _versionService = new VersionService();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            _logger.LogInformation("GetVersion");
            var version = _versionService.GetVersion();
            return Ok(new { version });
        }
    }
}