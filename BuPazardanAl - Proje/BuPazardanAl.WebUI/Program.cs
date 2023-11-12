using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Business.AutoMapper;
using BuPazardanAl.Business.Concrete;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Context;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.WebUI.BasketTransaction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.WebHost.UseSentry(o =>
//{
//    o.Dsn = "asdasd";
//    o.Debug = true;
//    o.TracesSampleRate = 1.0;
//});
builder.Services.AddControllersWithViews();






builder.Services.AddDbContext<BuPazardanAlContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BuPazardanAlContext>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<ICityDal, CityDal>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<IOrderDal, OrderDal>();
builder.Services.AddScoped<IOrderProcessService, OrderProcessManager>();
builder.Services.AddScoped<IProductOrderDal, ProductOrderDal>();
builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<ISellerDal, SellerDal>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ISellerService, SellerManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddTransient<IBasketTransaction,BasketTransaction>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseSentryTracing();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization(); // Yetki doðrulama

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
