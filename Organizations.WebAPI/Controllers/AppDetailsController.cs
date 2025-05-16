using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Organizations.Service.Dto;
using Organizations.Service.Interfaces;

namespace Organizations.WebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AppDetailsController : ControllerBase {
        private readonly IAppDetailsService _appDetailsService;
        public AppDetailsController(IAppDetailsService appDetailsService) {
            _appDetailsService = appDetailsService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestVersion(string code) {
            var version = await _appDetailsService.GetLatestVersionAsync(code);
            if (version == null)
                return NotFound("No version details found.");
            
            return Ok(version);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVersion([FromBody] AppDetailsDto dto) {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Code) || string.IsNullOrWhiteSpace(dto.Version))
                return BadRequest("Invalid version data.");

            var addedVersion = await _appDetailsService.AddVersionAsync(dto);
            return CreatedAtAction(nameof(GetLatestVersion), addedVersion);
        }
    }
}