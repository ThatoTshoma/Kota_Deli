using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KotaDeli.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "City Name")]
        public string Name { get; set; }
        [ValidateNever]
        public Province Province { get; set; }
        [Display(Name = "Province Name")]
        public int ProvinceId { get; set; }
    }
}
