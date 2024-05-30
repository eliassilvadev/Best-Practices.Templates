var builder = WebApplication.CreateBuilder(args);

var section = builder.Configuration.GetSection("AppSettings");

builder.Services.MapRepositories();
builder.Services.MapValidations();
builder.Services.MapUseCases();
builder.Services.MapCommandProviders();
builder.Services.MapHttpContextAccessor();
builder.Services.MapUnitOfWork();
builder.Services.MapConnection(section);

var app = DefaultApiConfiguration.Configure(builder);

Migrations.CreateDataBase(section["DatabaseServerName"], section["DatabaseName"]);

Migrations.Migrate(section["DatabaseServerName"], section["DatabaseName"], section["DatabaseUser"], section["DatabasePassWord"]);

app.Run();