using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class ProductDetailsConfig : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.ToTable("ProductDetails");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id");

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.NutritionDeclarationId)
                .HasColumnName("nutrition_declaration_id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(30);

            builder.Property(e => e.Price)
                .HasColumnName("price");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(60);

            builder.HasOne(d => d.NutritionDeclaration)
                .WithOne(p => p.ProductDetails)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
