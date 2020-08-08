using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration.Shoplist
{
    class ShoplistConfig : IEntityTypeConfiguration<Entities.Shoplist.Shoplist>
    {
        public void Configure(EntityTypeBuilder<Entities.Shoplist.Shoplist> builder)
        {
            builder.ToTable("Shoplist");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.OwnerId)
                .IsRequired()
                .HasColumnName("owner_id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.Description)
                .HasColumnName("description");

        }
    }
}
