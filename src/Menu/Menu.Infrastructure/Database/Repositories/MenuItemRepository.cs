using Menu.Domain;
using Menu.Infrastructure.Database.Entities;
using Menu.Infrastructure.Database.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Menu.Infrastructure.Database.Repositories;

public class MenuItemRepository
{
    private readonly MenuDatabaseContext _context;

    public MenuItemRepository(MenuDatabaseContext context)
    {
        _context = context;
    }
    public async Task SaveAsync(MenuItem item)
    {
        var mItem = new MenuItemEntity(item.Id, item.Name, item.Price, item.Description);
        await _context.MenuItems.AddAsync(mItem);
        await _context.SaveChangesAsync();
    }

    public async Task<List<MenuItem>> GetAllAsync()
    {
        var entities = await _context.MenuItems.ToListAsync();
        return entities.Select(e => new MenuItem(e.Id, e.Name, e.Price, e.Description)).ToList();
    }

    public async Task<MenuItem> GetAsync(int id)
    {
       var e = await _context.MenuItems.FirstAsync(e => e.Id == id);
       return new MenuItem(e.Id, e.Name, e.Price, e.Description);
    }
}