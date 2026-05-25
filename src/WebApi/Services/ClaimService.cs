using ClaimsTracker.Api.Data;
using ClaimsTracker.Api.Dtos;
using ClaimsTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimsTracker.Api.Services
{
    public class ClaimService : IClaimService
    {
        private readonly ClaimsTrackerDbContext _dbContext;

        public ClaimService(ClaimsTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClaimResponse> CreateClaimAsync(
            CreateClaimRequest request,
            CancellationToken cancellationToken)
        {
            var claim = new Claim
            {
                StatusId = request.StatusId,
                TypeId = request.TypeId,
                AssignedAdjusterId = request.AssignedAdjusterId,
            };

            _dbContext.Claims.Add(claim);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var createdClaim = await GetClaimByIdAsync(claim.Id, cancellationToken);

            if (createdClaim == null)
            {
                throw new InvalidOperationException("Claim was created but could not be retrieved.");
            }

            return createdClaim;
        }

        public async Task<ClaimResponse?> GetClaimByIdAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Claims
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ClaimResponse
                {
                    Id = x.Id,
                    Status = x.Status.StatusName,
                    Type = x.Type.TypeName,
                    AssignedAdjusterName = x.AssignedAdjuster == null ? null : x.AssignedAdjuster.FirstName + " " + x.AssignedAdjuster.LastName,
                    ReportedAt = x.ReportedAt
                })
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ClaimResponse>> GetClaimsAsync(
            CancellationToken cancellationToken)
        {
            return await _dbContext.Claims
                .AsNoTracking()
                .OrderByDescending(x => x.ReportedAt)
                .Select(x => new ClaimResponse
                {
                    Id = x.Id,
                    Status = x.Status.StatusName,
                    Type = x.Type.TypeName,
                    AssignedAdjusterName = x.AssignedAdjuster == null ? null : x.AssignedAdjuster.FirstName + " " + x.AssignedAdjuster.LastName,
                    ReportedAt = x.ReportedAt
                })
                .ToListAsync(cancellationToken);
        }
    }
}
