namespace ClaimsTracker.Api.Dtos
{
    public record CreateClaimRequest
    {
        public int StatusId { get; init; }
        public int TypeId { get; init; }
        public int? AssignedAdjusterId { get; init; }
    }
}
