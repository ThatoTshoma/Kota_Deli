using KotaDeli.Data.Base;
using KotaDeli.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KotaDeli.Data.Services
{
    public class MenuService: IMenuService
    {
        private readonly ApplicationDbContext _db;
        public MenuService(ApplicationDbContext context)
        {
            _db = context;
        }

        public Task Add(Menu entity)
        {
            throw new NotImplementedException();
        }

        public Task AddMenuProduct(Menu data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Menu>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Menu>> GetAll(params Expression<Func<Menu, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetById(int id, params Expression<Func<Menu, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Menu>> GetMenuById()
        {
            return await _db.Menus.ToListAsync();
        }


        public async Task<Menu> GetMenuById(int id)
        {
            var menu = await _db.Menus.FirstOrDefaultAsync(n => n.MenuId == id);

            return menu;
        }

        public Task Update(int id, Menu entity)
        {
            throw new NotImplementedException();
        }

        Task<Menu> IEntityBaseRepository<Menu>.GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
