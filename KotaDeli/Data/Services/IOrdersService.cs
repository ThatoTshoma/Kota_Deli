using KotaDeli.Models;

namespace KotaDeli.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<CartItem> items, int customerId, string deliveryOption);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(int userId, string userRole);

    }
}
