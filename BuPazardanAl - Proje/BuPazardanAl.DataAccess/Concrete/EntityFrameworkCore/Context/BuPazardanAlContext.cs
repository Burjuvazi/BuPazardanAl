using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Maps;
using BuPazardanAl.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class BuPazardanAlContext : IdentityDbContext<AppUser,AppRole,int>
    {
        //public BuPazardanAlContext(DbContextOptions<BuPazardanAlContext> options):base(options)
        //{


        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CHSJJ4J\SQLEXPRESS;Initial Catalog=BuPazardanAlDb;Trusted_Connection=true;TrustServerCertificate=True");

            //optionsBuilder.UseSqlServer(@"Server=ServerName;Initial Catalog=VeritabaniAdi;uid=sa;pwd=123;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductOrder>().HasKey(x=>new {x.OrderId,x.ProductId });
            builder.Entity<SellerProduct>().HasKey(x=> new {x.SellerId,x.ProductId });
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new SellerMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CityMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new OrderMap());
            base.OnModelCreating(builder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }
    }
}
