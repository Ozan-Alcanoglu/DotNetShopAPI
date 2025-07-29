using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FirstCSBackend.Data;
using FirstCSBackend.Repositories.Interfaces;
using FirstCSBackend.Repositories;
using FirstCSBackend.Services.Interfaces;
using FirstCSBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL ba�lant�s� ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC deste�i ekle (API + Views)
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirstCSBackend API", Version = "v1" });
});

// Scoped service kay�tlar�
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

// Kestrel portunu builder a�amas�nda ayarla
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5000);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstCSBackend API v1");
    c.RoutePrefix = string.Empty; // Swagger'� ana sayfa yap
});

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
