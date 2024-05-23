using fiorellopb101.Data;
using fiorellopb101.Servioces;
using fiorellopb101.Servioces.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISliderServices, SliderServices>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
