using KotaDeli.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace KotaDeli.Models
{
    public class Menu : IEntityBase
    {
        [Key]
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get;set; }
    }
}
