using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FirstCSBackend.Data;
using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Repositories;
using FirstCSBackend.Services.Interfaces;
using FirstCSBackend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL baðlantýsý ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirstCSBackend API", Version = "v1" });
});

// Scoped service kayýtlarý
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

var app = builder.Build();

// Swagger her ortamda açýk
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstCSBackend API v1");
    c.RoutePrefix = string.Empty; // Swagger ana sayfa olarak açýlýr
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Kestrel server portu zorla 5000 olarak ayarla
app.Urls.Clear();
app.Urls.Add("http://localhost:5000");

app.Run();
