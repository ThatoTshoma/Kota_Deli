using System.ComponentModel.DataAnnotations.Schema;

namespace KotaDeli.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }       
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
