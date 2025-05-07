using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KotaDeli.Models
{
    public class Suburb
    {
        public int SuburbId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }
        [ValidateNever]
        public City City { get; set; }
        [Display(Name = "City Name")]
        public int CityId { get; set; }
    }
}
