using Data.Entities.Shoplist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration.Shoplist
{
    class ShoplistUserConfig : IEntityTypeConfiguration<ShoplistUser>
    {
        public void Configure(EntityTypeBuilder<ShoplistUser> builder)
        {
            builder.ToTable("ShoplistUser");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.RoleId)
                .IsRequired()
                .HasColumnName("role_id")
                .HasDefaultValue(3);

            builder.Property(e => e.ShoplistId)
                .IsRequired()
                .HasColumnName("shoplist_id");
        }
    }
}
