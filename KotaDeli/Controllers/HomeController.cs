using KotaDeli.Data;
using KotaDeli.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace KotaDeli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        private List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant {RestaurantId = 1, Name = "Kasi Restaurant", AddressLine1= "123 Soweto Street, Johannesburg", ImageUrl = "/Images/kota.jpg"},
            new Restaurant {RestaurantId = 2, Name = "My Restaurant", AddressLine1= "145 Tembisa Street, Johannesburg", ImageUrl = "/Images/kota.jpg"},
            new Restaurant {RestaurantId = 3, Name = "KFC", AddressLine1= "145 Kenya Street, Johannesburg", ImageUrl = "/Images/kota.jpg"},
        };

        private List<Menu> menus = new List<Menu>
        {
            new Menu { MenuId = 1, Name = "Kota Special", Description = "A delicious kota with polony, cheese & atchar.", Price = 35.99, ImageUrl = "/Images/kota.jpg", RestaurantId = 1 },
            new Menu { MenuId = 2, Name = "Burger Meal", Description = "Juicy beef burger with fries.", Price = 49.99, ImageUrl = "/Images/kota.jpg", RestaurantId = 2 },
            new Menu { MenuId = 3, Name = "Zinger Box Meal", Description = "Zinger burger with spicy wings & fries.", Price = 69.99, ImageUrl = "/Images/kota.jpg", RestaurantId = 3 },
            new Menu { MenuId = 3, Name = "Zinger Box Meal", Description = "Zinger burger with spicy wings & fries.", Price = 69.99, ImageUrl = "/Images/kota.jpg", RestaurantId = 3 },

        };

        public IActionResult Index()
        {
            var restaurant = _db.Restaurants.ToList();
            return View(restaurant);
        }

        public IActionResult Menu(int id)
        {
            var menu = _db.Menus.Where(m => m.RestaurantId == id).ToList();

            if (menu == null)
            {
                return NotFound("No menu found for this restaurant.");
            }
            return View(menu);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
