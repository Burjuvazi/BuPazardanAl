using BuPazardanAl.Core.Maps;
using BuPazardanAl.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Maps
{
    public class ProductMap : CoreMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.ProductOrders).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);

            builder.HasMany(x => x.SellerProducts).WithOne(x => x.Product).HasForeignKey(x=>x.ProductId);

            base.Configure(builder);
        }
    }
}
