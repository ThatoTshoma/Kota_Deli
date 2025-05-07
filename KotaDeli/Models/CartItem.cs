using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace KotaDeli.Models
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        
        public string TempId {  get; set; } 

    }
}
