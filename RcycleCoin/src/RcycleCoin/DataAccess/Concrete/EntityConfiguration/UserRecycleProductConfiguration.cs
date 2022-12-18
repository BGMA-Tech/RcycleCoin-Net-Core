using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class UserRecycleProductConfiguration : IEntityTypeConfiguration<UserRecycleProduct>
    {
        public void Configure(EntityTypeBuilder<UserRecycleProduct> builder)
        {
            #region UserRecycleProduct Model Creation
            builder.ToTable("UserRecycleProduct").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id").UseIdentityColumn(1, 1);
            builder.Property(u => u.RecycleProductId).HasColumnName("RecycleProductId").IsRequired();
            builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(u => u.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(u => u.CreatedAt).HasColumnName("CreatedAt").IsRequired();

            builder.HasOne(u => u.RecycleProduct);
            #endregion
        }
    }

}
