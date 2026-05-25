using ClaimsTracker.Api.Dtos;
using ClaimsTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ClaimResponse>>> GetClaims(
            CancellationToken cancellationToken)
        {
            var claims = await _claimService.GetClaimsAsync(cancellationToken);

            return Ok(claims);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClaimResponse>> GetClaimById(
            int id,
            CancellationToken cancellationToken)
        {
            var claim = await _claimService.GetClaimByIdAsync(id, cancellationToken);

            if (claim == null) 
            {
                return NotFound();
            }

            return Ok(claim);
        }

        [HttpPost]
        public async Task<ActionResult<ClaimResponse>> CreateClaim(
            CreateClaimRequest request,
            CancellationToken cancellationToken)
        {
            var claim = await _claimService.CreateClaimAsync(request, cancellationToken);

            return CreatedAtAction(
                nameof(GetClaimById),
                new
                {
                    id = claim.Id
                },
                claim);
        }

    }
}
