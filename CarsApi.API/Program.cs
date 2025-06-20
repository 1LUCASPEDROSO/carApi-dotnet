
using CarsApi.Application.Interfaces;
using CarsApi.Application.Services;
using CarsApi.Application.Services.Impl;
using CarsApi.Domain.Services;
using CarsApi.Domain.Services.Impl;
using CarsApi.Infrastructure;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

                                        var builder = WebApplication.CreateBuilder(args);

                                        builder.Services.AddDbContext<AppDbContext>(options =>
                                        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

                                        builder.Services.AddScoped<IBrandService, BrandService>();
                                        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
                                        builder.Services.AddScoped<IModelService, ModelService>();
                                        builder.Services.AddScoped<IModelRepository, ModelRepository>();
                                        builder.Services.AddScoped<ICarRepository, CarRepository>();
                                        builder.Services.AddScoped<ICarService, CarService>();

                                        builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
