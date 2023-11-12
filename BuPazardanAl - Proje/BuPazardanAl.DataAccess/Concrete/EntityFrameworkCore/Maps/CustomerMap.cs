using BuPazardanAl.Core.Maps;
using BuPazardanAl.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Maps
{
    public class CustomerMap : CoreMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x=>x.LastName).IsRequired();

            builder.HasOne(x => x.AppUser).WithOne(x => x.Customer).HasPrincipalKey<AppUser>(x=>x.Id);

            builder.HasMany(x => x.Orders).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId);

            base.Configure(builder);
        }
    }
}
