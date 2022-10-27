using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Services;
using ReastaurantManagement.Services.Implementations;
using ReastaurantManagement.Services.Interfaces;
using RestaurantManagement.Services.Implementations.Report;
using RestaurantManagment.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDatabase"))
);

RegisterServices(builder);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/accessdenied";
        options.AccessDeniedPath = "/accessdenied";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/accessdenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied");
});

app.MapControllers();

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IMenuService, MenuService>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
    builder.Services.AddScoped<IReportService, ReportService>();
    builder.Services.AddScoped<ProductReportService>();
    builder.Services.AddScoped<EmployeeReportService>();
    builder.Services.AddScoped<MenuReportService>();
}