using Menu.Infrastructure.Database.Infrastructure;
using Menu.Infrastructure.Database.Repositories;
using Menu.Messages;
using Menu.Worker;
using Menu.Worker.Handlers;
using Rebus.Config;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<MenuDatabaseContext>();
builder.Services.AddTransient<MenuItemRepository>();
builder.Services.AddRebusHandler<CreateMenuItemCommmandHandler>();

builder.Services.AddRebus((configurer, provider) =>
{
    configurer.Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost:5672", ServiceConstants.InputQueue));
    configurer.Logging(l => l.ColoredConsole());
    configurer.Options(o => o.SetNumberOfWorkers(5));
    return configurer;
}, onCreated:  bus =>
{
    //Subscribe to events here.
    return Task.CompletedTask;
});

builder.Services.AddNpgsql<MenuDatabaseContext>(builder.Configuration.GetConnectionString("Postgres"));

var host = builder.Build();
host.Run();