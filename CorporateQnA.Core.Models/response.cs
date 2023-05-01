namespace CorporateQnA.Core.Models
{
    public class response
    {
        public string Status { get; set; }

        public string StatusMessage { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public Guid ActiveEmployeeId { get; set; } = Guid.Empty;
    }
}
