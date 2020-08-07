using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class ResetPasswordConfig : IEntityTypeConfiguration<ResetPassword>
    {
        public void Configure(EntityTypeBuilder<ResetPassword> builder)
        {
            builder.ToTable("ResetPassword");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.ConfirmationNumber)
                .IsRequired()
                .HasColumnName("confirmation_number");

            builder.Property(e => e.ResetDate)
                .IsRequired()
                .HasColumnName("reset_date");
        }
    }
}
