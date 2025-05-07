using KotaDeli.Models;
using Microsoft.EntityFrameworkCore;

namespace KotaDeli.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _db;
        public OrdersService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task StoreOrderAsync(List<CartItem> items, int customerId, double deliveryFee)
        {
            var order = new Order()
            {
                CustomerId = customerId,
                DeliveryFee = deliveryFee,
                Date = DateTime.Now
            };

            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    MenuId = item.Menu.MenuId,
                    OrderId = order.OrderId,
                    Price = (double)item.Menu.Price
                };
                await _db.OrderItems.AddAsync(orderItem);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(int userId, string userRole)
        {
            var orders = await _db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Menu).Include(n => n.Customer).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.CustomerId == userId).ToList();
            }

            return orders;
        }
    }
}
