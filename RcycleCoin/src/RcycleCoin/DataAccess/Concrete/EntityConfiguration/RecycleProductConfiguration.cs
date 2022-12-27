using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class RecycleProductConfiguration : IEntityTypeConfiguration<RecycleProduct>
    {
        public void Configure(EntityTypeBuilder<RecycleProduct> builder)
        {
            #region RecycleProduct Model Creation
            builder.ToTable("RecycleProduct").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.RecycleTypeId).HasColumnName("RecycleTypeId").IsRequired();
            builder.Property(u => u.RecycleName).HasColumnName("RecycleName").HasMaxLength(50).IsRequired();
            builder.Property(u => u.RecyclePoint).HasColumnName("RecyclePoint").IsRequired();

            builder.HasOne(u => u.RecycleType).WithMany().HasForeignKey(x=> x.RecycleTypeId);
            builder.HasOne(u => u.RecycleProductImage).WithMany().HasForeignKey(x => x.RecycleProductImageId);
            #endregion
        }
    }

}
