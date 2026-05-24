namespace ClaimsTracker.Api.Entities
{
    public class ClaimType
    {
        public int Id { get; set; }
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
