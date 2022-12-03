using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class RecycleTypeConfiguration : IEntityTypeConfiguration<RecycleType>
    {
        public void Configure(EntityTypeBuilder<RecycleType> builder)
        {
            #region RecycleType Model Creation
            builder.ToTable("RecycleType").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id").UseIdentityColumn(1, 1);
            builder.Property(u => u.RecycleTypeName).HasColumnName("RecycleTypeName").HasMaxLength(50).IsRequired();
            #endregion
        }
    }

}
