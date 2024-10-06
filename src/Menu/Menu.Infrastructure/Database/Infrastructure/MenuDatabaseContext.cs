using Menu.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Menu.Infrastructure.Database.Infrastructure;

public class MenuDatabaseContext(DbContextOptions<MenuDatabaseContext> options) : DbContext(options)
{
    public DbSet<MenuItemEntity> MenuItems { get; set; }
}