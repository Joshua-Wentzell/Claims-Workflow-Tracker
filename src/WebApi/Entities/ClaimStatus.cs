namespace ClaimsTracker.Api.Entities
{
    public class ClaimStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
