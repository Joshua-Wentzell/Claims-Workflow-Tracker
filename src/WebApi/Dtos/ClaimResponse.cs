namespace ClaimsTracker.Api.Dtos
{
    public record ClaimResponse
    {
        public int Id { get; init; }
        public string Status { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
        public string? AssignedAdjusterName { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}
