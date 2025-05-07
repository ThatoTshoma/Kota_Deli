using KotaDeli.Data;
using KotaDeli.Data.Services;
using KotaDeli.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KotaDeli.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly Cart _cart;
        private readonly IMenuService _menuService;
        private readonly ICartService _cartService;
        private readonly IOrdersService _ordersService;

        public OrderController(ApplicationDbContext db, Cart cart, IMenuService menuService, ICartService cartService, IOrdersService ordersService)
        {
            _db = db;
            _cart = cart;
            _menuService = menuService;
            _cartService = cartService;
            _ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerAddress = _db.Customers.Include(c => c.Suburb).ThenInclude(s => s.City).ThenInclude(c => c.Province).FirstOrDefault(c => c.UserId.ToString() == userId);
            var items = _cart.GetCartItems();
            _cart.Items = items;

            var response = new CartViewModel()
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };
            ViewBag.CustomerAddress = customerAddress;
            return View(response);
        }
        [Authorize]
        public async Task<IActionResult> AddItemToCart(int id)
        {
            var item = await _menuService.GetMenuById(id);

            if (item != null)
            {
                _cart.AddItem(item);
            }
            return RedirectToAction(nameof(Cart));
        }
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var item = await _menuService.GetMenuById(id);

            if (item != null)
            {
                _cart.RemoveItem(item);
            }
            return RedirectToAction(nameof(Cart));
        }
        public IActionResult Checkout(int Id)
        {
            var items = _cartService.GetCartById(Id);

            return View(items);

        }
        // [HttpPost]
        public async Task<IActionResult> PlaceOrder(string deliveryOption)
        {
            var items = _cart.GetCartItems();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.SingleOrDefault(c => c.UserId.ToString() == userId);

            double deliveryFee = deliveryOption == "delivery" ? 10.00 : 0.00;

            await _ordersService.StoreOrderAsync(items, customer.CustomerId, deliveryFee);
            await _cart.ClearCart();

            return RedirectToAction("Order", "Customer");
        }

    }
}
