using ClaimsTracker.Api.Dtos;

namespace ClaimsTracker.Api.Services
{
    public interface IClaimService
    {
        Task<ClaimResponse> CreateClaimAsync(CreateClaimRequest request, CancellationToken cancellationToken);
        Task<ClaimResponse?> GetClaimByIdAsync(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<ClaimResponse>> GetClaimsAsync(CancellationToken cancellationToken);
    }
}
