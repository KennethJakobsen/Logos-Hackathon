using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var dbuser = builder.AddParameter("db-user", true);
var dbpass = builder.AddParameter("db-pass", true);
var postgres = builder.AddPostgres("postgres", dbuser, dbpass)
    .AddDatabase("menu");

var rabbit = builder.AddRabbitMQ("rabbit");

var menu = builder.AddProject<Projects.Menu_Api>("menu-api")
    .WithReference(postgres);
var menuworker = builder.AddProject<Projects.Menu_Worker>("menu-worker")
    .WithReference(postgres)
    .WithReference(rabbit);

var gateway = builder.AddProject<Projects.Gateway>("gateway")
    .WithReference(menu)
    .WithReference(menuworker)
    .WithReference(rabbit);

builder.AddProject<PizzaFrontend>("frontend")
    .WithReference(gateway);

builder.Build().Run();