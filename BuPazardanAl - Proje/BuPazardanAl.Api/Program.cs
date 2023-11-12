using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Business.AutoMapper;
using BuPazardanAl.Business.Concrete;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Context;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(x => x.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(x => true)));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keykullaniyorumburada"))
    };
});


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
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ISellerService, SellerManager>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
