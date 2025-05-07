using KotaDeli.Models;
using Microsoft.EntityFrameworkCore;

namespace KotaDeli.Data
{
    public class Cart
    {
        public string CartId { get; set; }
        public ApplicationDbContext _db { get; set; }
        public List<CartItem> Items { get; set; }


        public Cart(ApplicationDbContext db)
        {
            _db = db;
        }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddItem(Menu menu)
        {
            var cartItem = _db.CartItems.FirstOrDefault(n => n.Menu.MenuId == menu.MenuId && n.TempId == CartId);

            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    TempId = CartId,
                    Menu = menu,
                    Price = menu.Price,
                    Quantity = 1
                };

                _db.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _db.SaveChanges();

        }

        public void RemoveItem(Menu menu)
        {
            var cartItem = _db.CartItems.FirstOrDefault(n => n.Menu.MenuId == menu.MenuId && n.TempId == CartId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    _db.CartItems.Remove(cartItem);
                }
            }
            _db.SaveChanges();

        }

        public List<CartItem> GetCartItems()
        {
            return Items ?? (Items = _db.CartItems.Where(n => n.TempId == CartId).Include(n => n.Menu).ToList());
        }
        public double GetCartTotal()
        {
            return _db.CartItems.Where(item => item.TempId == CartId).Sum(item => item.Menu.Price * item.Quantity);
        }

        public async Task ClearCart()
        {
            var items = await _db.CartItems.Where(n => n.TempId == CartId).ToListAsync();
            _db.CartItems.RemoveRange(items);
            await _db.SaveChangesAsync();
        }

    }

}
