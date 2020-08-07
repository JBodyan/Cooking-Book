using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("firstname")
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastname")
                .HasMaxLength(20);

            builder.Property(e => e.MiddleName)
                .HasColumnName("middlename")
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(40);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(100);

            builder.Property(e => e.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("datetime2");

            builder.Property(e => e.RegisteredDate)
                .HasColumnName("registered_date")
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.RoleId)
                .HasColumnName("role_id")
                .HasDefaultValue(1);

            builder.Property(e => e.IsEmailConfirmed)
               .IsRequired().HasDefaultValue(1)
               .HasColumnName("email_confirmed")
               .HasColumnType("bit");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
