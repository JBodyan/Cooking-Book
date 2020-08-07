using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class NutritionDeclarationConfig : IEntityTypeConfiguration<NutritionDeclaration>
    {
        public void Configure(EntityTypeBuilder<NutritionDeclaration> builder)
        {
            builder.ToTable("NutritionDeclaration");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.DetailsId)
                .HasColumnName("details_id");
        }
    }
}
