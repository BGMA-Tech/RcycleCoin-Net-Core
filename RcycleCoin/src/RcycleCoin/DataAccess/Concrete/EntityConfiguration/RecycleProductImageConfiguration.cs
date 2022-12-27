using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class RecycleProductImageConfiguration : IEntityTypeConfiguration<RecycleProductImage>
    {
        public void Configure(EntityTypeBuilder<RecycleProductImage> builder)
        {
            #region RecycleProductImage Model Creation
            builder.ToTable("RecycleProductImage").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.ImagePath).HasColumnName("ImagePath").IsRequired();
            #endregion
        }
    }
}
