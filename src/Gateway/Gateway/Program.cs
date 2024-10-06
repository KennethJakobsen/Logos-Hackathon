using Gateway.DTO;
using Menu.Client.Api;
using Menu.Messages;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Routing.TypeBased;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MenuApiApi>(s => new MenuApiApi(builder.Configuration.GetSection("services").GetSection("menu-api").GetSection("http")["0"]));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRebus(configurer => configurer
        .Transport(t => t.UseRabbitMqAsOneWayClient(builder.Configuration.GetConnectionString("rabbit")))
        .Routing(r => r.TypeBased().MapAssemblyOf<CreateMenuItemCommand>(MenuServiceConstants.InputQueue))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Menu/", async ([FromServices] MenuApiApi apiClient) => await apiClient.GetMenuAllItemsAsync())
    .WithName("GetAlle´MenuItems");
app.MapPost("/Menu/{id:int}", async (int id, CreateMenuItemRequest req, IBus bus) =>
    {
        await bus.Send(new CreateMenuItemCommand(id, req.Name, req.Price, req.Description));
        return Results.Accepted();
    })
    .WithName("CreatMenuItem")
    .WithOpenApi();

app.Run();

