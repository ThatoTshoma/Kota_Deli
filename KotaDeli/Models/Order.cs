using KotaDeli.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotaDeli.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; } 

        public double DeliveryFee { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        //Thato

        public List<OrderItem> OrderItems { get; set; }
    }
}
