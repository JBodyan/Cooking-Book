using Data.Entities.Shoplist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration.Shoplist
{
    class ShoplistProductConfig : IEntityTypeConfiguration<ShoplistProduct>
    {
        public void Configure(EntityTypeBuilder<ShoplistProduct> builder)
        {
            builder.ToTable("ShoplistProduct");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name");
            
            builder.Property(e => e.Description)
                .HasColumnName("description");

            builder.Property(e => e.Price)
                .HasColumnName("price");
        }
    }
}
