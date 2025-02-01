using Notissimus.PointerTracking.Domain.Interfaces;
using Notissimus.PointerTracking.Infrastructure;
using Notissimus.PointerTracking.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<IPointerTrackingDb, PointerTrackingDb>(
    DbOptions.Set, ServiceLifetime.Singleton);

var app = builder.Build();

Console.WriteLine("use {dotnet ef database update}");