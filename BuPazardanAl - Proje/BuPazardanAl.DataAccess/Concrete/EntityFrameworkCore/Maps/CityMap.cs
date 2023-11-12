using BuPazardanAl.Core.Maps;
using BuPazardanAl.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Maps
{
    public class CityMap : CoreMap<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x=>x.Customers).WithOne(x=>x.City).HasForeignKey(x=>x.CityId);

            base.Configure(builder);
        }
    }
}
