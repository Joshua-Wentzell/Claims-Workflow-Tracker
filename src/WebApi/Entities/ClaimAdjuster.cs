namespace ClaimsTracker.Api.Entities
{
    public class ClaimAdjuster
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public DateTime HiredAt { get; set; }
        public bool IsActive { get; set; }
    }
}
