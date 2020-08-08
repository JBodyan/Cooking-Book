using Data.Entities.Shoplist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration.Shoplist
{
    class ShoplistCategoryConfig : IEntityTypeConfiguration<ShoplistCategory>
    {
        public void Configure(EntityTypeBuilder<ShoplistCategory> builder)
        {
            builder.ToTable("ShoplistCategory");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.Description)
                .HasColumnName("description");
        }
    }
}
