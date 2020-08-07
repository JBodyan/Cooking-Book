using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50);
        }
    }
}
