using asteroid_fever.Application.Interfaces;
using asteroid_fever.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace asteroid_fever.Presentation.Controllers
{
    [Route("api/impact")]
    [ApiController]
    public class ImpactController : ControllerBase
    {
        private readonly IImpactService _impactService;

        public ImpactController(IImpactService impactService)
        {
            _impactService = impactService;
        }

        [HttpPost]
        public async Task<IActionResult> GetImpact([FromBody] ImpactFactors impactFactors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var impactResult = await _impactService.DetermineImpactTier(impactFactors);

            if (impactResult == null)
            {
                return NotFound("No matching impact tier found.");
            }

            return Ok(impactResult);
        }
    }
}
