using Menu.Infrastructure.Database.Infrastructure;
using Menu.Infrastructure.Database.Repositories;
using Menu.Messages;
using Menu.Worker;
using Menu.Worker.Handlers;
using Microsoft.EntityFrameworkCore;
using Rebus.Config;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddTransient<MenuItemRepository>();
builder.Services.AddRebusHandler<CreateMenuItemCommmandHandler>();

builder.Services.AddRebus((configurer, provider) =>
{
    configurer.Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("rabbit"), MenuServiceConstants.InputQueue));
    configurer.Logging(l => l.ColoredConsole());
    configurer.Options(o => o.SetNumberOfWorkers(5));
    return configurer;
}, onCreated:  bus =>
{
    //Subscribe to events here.
    return Task.CompletedTask;
});

builder.Services.AddDbContext<MenuDatabaseContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("menu"), x => x.MigrationsAssembly("Menu.Infrastructure")));


var host = builder.Build();

await Task.Delay(5000);
await using var scope = host.Services.CreateAsyncScope();
await using var db = scope.ServiceProvider.GetService<MenuDatabaseContext>();
var pending = await db.Database.GetPendingMigrationsAsync();
if(pending.Any())
    db.Database.Migrate();

host.Run();