using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace KotaDeli.Models
{
    public class Restaurant
    {
        [Key] 
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }   
        public string AddressLine1 { get; set; }
        public string ImageUrl { get; set; }

    }
}
