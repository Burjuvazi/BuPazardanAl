using BuPazardanAl.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuPazardanAl.Core.Maps
{
    public class CoreMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class,IEntity,new()
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

        }
    }
}
