using KotaDeli.Data.Base;
using KotaDeli.Models;

namespace KotaDeli.Data.Services
{
    public interface IMenuService : IEntityBaseRepository<Menu>
    {
        Task GetAll(Func<object, object> value);
        Task GetById(int id);
        Task<Menu> GetMenuById(int id);
        Task AddMenuProduct(Menu data);
    }
}
