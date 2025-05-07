using Microsoft.AspNetCore.Mvc;

namespace KotaDeli.Data.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart _cart;
        public CartSummary(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _cart.GetCartItems();

            return View(items.Count);
        }
    }
}

