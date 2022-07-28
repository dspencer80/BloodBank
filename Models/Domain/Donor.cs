namespace BloodBank.Models.Domain
{
    public class Donor
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Social { get; set; }
        public string? Email { get; set; }
        public string? Race { get; set; }
        public DateTime? DateofBirth { get; set; }
        public DateTime? DonationDate { get; set; }
        
    }
}
