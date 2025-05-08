using KotaDeli.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotaDeli.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; } 

        public string DeliveryOption { get; set; }
        public string Status { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
