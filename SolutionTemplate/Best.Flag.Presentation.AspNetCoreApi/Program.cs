using $ext_safeprojectname$.Cqrs.Dapper.Configurations;
using $ext_safeprojectname$.Cqrs.Dapper.Migrations;
using $ext_safeprojectname$.Core.Configurations;
using $ext_safeprojectname$.Presentation.AspNetCoreApi.Configurations;
using Best.Practices.Core.Presentation.AspNetCoreApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

var section = builder.Configuration.GetSection("AppSettings");

builder.Services.MapRepositories();
builder.Services.MapValidations();
builder.Services.MapUseCases();
builder.Services.MapCommandProviders();
builder.Services.MapQueryProviders();
builder.Services.MapHttpContextAccessor();
builder.Services.MapUnitOfWork();
builder.Services.MapConnection(section);

var app = DefaultApiConfiguration.Configure(builder);

Migrations.CreateDataBase(section["DatabaseServerName"], section["DatabaseName"]);

Migrations.Migrate(section["DatabaseServerName"], section["DatabaseName"], section["DatabaseUser"], section["DatabasePassWord"]);

app.Run();