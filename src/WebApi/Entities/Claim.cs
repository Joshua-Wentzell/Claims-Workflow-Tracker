using System.Security.Claims;

namespace ClaimsTracker.Api.Entities
{
    public class Claim
    {
        public int Id { get; set; }

        public int StatusId { get; set; }
        public ClaimStatus Status { get; set; } = null!;

        public int TypeId { get; set; }
        public ClaimType Type { get; set; } = null!;

        public DateTime ReportedAt { get; set; }

        public int? AssignedAdjusterId { get; set; }
        public ClaimAdjuster? AssignedAdjuster { get; set; }
    }
}
