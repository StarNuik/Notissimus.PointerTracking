using Notissimus.PointerTracking.Domain.Interfaces;
using Notissimus.PointerTracking.Infrastructure;
using Notissimus.PointerTracking.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDatabases(builder.Configuration);

var app = builder.Build();

Console.WriteLine("use {dotnet ef database update}");