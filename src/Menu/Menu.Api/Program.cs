using Menu.Infrastructure.Database.Infrastructure;
using Menu.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MenuDatabaseContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("menu")));
builder.Services.AddTransient<MenuItemRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Menu", async ([FromServices]MenuItemRepository repo) => await repo.GetAllAsync())
    .WithName("GetMenuAllItems")
    .WithOpenApi();

app.Run();
