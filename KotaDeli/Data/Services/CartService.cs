using KotaDeli.Models;
using Microsoft.EntityFrameworkCore;

namespace KotaDeli.Data.Services
{
    public class CartService: ICartService
    {
        private readonly ApplicationDbContext _db;
        public CartService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<CartItem> GetCartById(int id)
        {
            var cart = await _db.CartItems.FirstOrDefaultAsync(n => n.CartId == id);

            return cart;
        }

    }
}
