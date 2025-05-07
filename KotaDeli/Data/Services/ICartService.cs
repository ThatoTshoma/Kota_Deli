using KotaDeli.Data.Base;
using KotaDeli.Models;

namespace KotaDeli.Data.Services
{
    public interface ICartService 
    {
        Task<CartItem> GetCartById(int id);
    }
}
