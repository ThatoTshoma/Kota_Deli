using KotaDeli.Data;
using KotaDeli.Data.Services;
using KotaDeli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KotaDeli.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ApplicationDbContext _db;
        public CustomerController(IOrdersService ordersService, ApplicationDbContext db)
        {
            _ordersService = ordersService;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }
        public async Task<IActionResult> UpdateProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var patient = await _db.Customers.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(Customer model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var patient = await _db.Customers.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            patient.Name = model.Name;
            patient.Surname = model.Surname;
            patient.EmailAddress = model.EmailAddress;
            patient.ContactNumber = model.ContactNumber;

            ViewBag.message = "Profile successfully updated";
            _db.SaveChanges();
            return View();
        }
        public IActionResult LoadSuburbs(int cityId)
        {
            var suburbs = _db.Suburbs.Where(s => s.CityId == cityId).OrderBy(s => s.Name).Select(s => new { suburbID = s.SuburbId, suburbName = s.Name }).ToList();
            return Json(suburbs);
        }
        public IActionResult LoadCity(int provinceId)
        {
            var cities = _db.Cities
                .Where(s => s.ProvinceId == provinceId)
                .OrderBy(s => s.Name)
                .Select(s => new { cityId = s.CityId, cityName = s.Name })
                .ToList();
            return Json(cities);
        }

        public IActionResult LoadSuburb(int cityId)
        {
            var suburbs = _db.Suburbs
                .Where(s => s.CityId == cityId)
                .OrderBy(s => s.Name)
                .Select(s => new {
                    suburbId = s.SuburbId,
                    suburbName = s.Name,
                    postalCode = s.PostalCode
                })
                .ToList();
            return Json(suburbs);
        }

        public async Task<IActionResult> UpdateAddress()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.Customers.Include(c => c.Suburb).ThenInclude(s => s.City).ThenInclude(c => c.Province).SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            ViewBag.ProvinceList = new SelectList(_db.Provinces.OrderBy(c => c.Name), "ProvinceId", "Name");

            if (customer?.Suburb != null)
            {
                ViewBag.CityList = new SelectList(_db.Cities.Where(c => c.ProvinceId == customer.Suburb.City.ProvinceId).OrderBy(c => c.Name),"CityId", "Name", customer.Suburb.CityId);

                ViewBag.SuburbList = new SelectList(_db.Suburbs.Where(s => s.CityId == customer.Suburb.CityId).OrderBy(s => s.Name),"SuburbId", "Name", customer.SuburbId);
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(Customer model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.Customers.SingleOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (customer != null)
            {
                customer.AddressLine1 = model.AddressLine1;
                customer.AddressLine2 = model.AddressLine2;
                customer.SuburbId = model.SuburbId;

                _db.SaveChanges();
                ViewBag.message = "Delivery address successfully updated";
            }

            ViewBag.ProvinceList = new SelectList(_db.Provinces.OrderBy(c => c.Name), "ProvinceId", "Name");
            return View(model);
        }
        public async Task<IActionResult> Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.Customers.SingleOrDefaultAsync(x => x.UserId.ToString() == userId);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(customer.CustomerId, userRole);
            return View(orders);
        }
    }
}
