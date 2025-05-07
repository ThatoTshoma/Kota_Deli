using KotaDeli.Models;

namespace KotaDeli.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<CartItem> items, int customerId, double deliveryFee);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(int userId, string userRole);

    }
}
