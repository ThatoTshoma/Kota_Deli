using KotaDeli.Data;

namespace KotaDeli.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; } 
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public Suburb Suburb { get; set; }
        public int? SuburbId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId {  get; set; }
    }
}
