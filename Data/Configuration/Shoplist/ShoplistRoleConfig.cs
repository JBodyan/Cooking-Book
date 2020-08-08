using Data.Entities.Shoplist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration.Shoplist
{
    class ShoplistRoleConfig : IEntityTypeConfiguration<ShoplistRole>
    {
        public void Configure(EntityTypeBuilder<ShoplistRole> builder)
        {
            builder.ToTable("ShoplistRole");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(20);
        }
    }
}
