using Menu.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Menu.Infrastructure.Database.Infrastructure;

public class MenuDatabaseContext : DbContext
{
    public DbSet<MenuItemEntity> MenuItems { get; set; }
}