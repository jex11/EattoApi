using System;
using System.Reflection;
using Eatto.Application;
using Eatto.Application.Interfaces;
using Eatto.Application.UseCases.Queries;
using Eatto.Core.Database;
using Eatto.Infrastructure;
using Eatto.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<IAutoInjectable>() // Eatto.Infrastructure
    .AddClasses(c => c.AssignableTo<IAutoInjectable>())
    .AsImplementedInterfaces()
    .WithScopedLifetime());

//builder.Services.AddApplicationServices(Assembly.GetAssembly(typeof(IAutoInjectable))!,        // Eatto.Application
    //Assembly.GetAssembly(typeof(CategoryRepository))!);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesHandler).Assembly));

// Log what was registered
foreach (var service in builder.Services)
{
    if (service.ImplementationType != null &&
        typeof(IAutoInjectable).IsAssignableFrom(service.ServiceType))
    {
        Console.WriteLine($"Registered: {service.ServiceType.Name} --> {service.ImplementationType.Name}");
    }
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
