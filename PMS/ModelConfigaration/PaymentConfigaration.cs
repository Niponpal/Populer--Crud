using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration;

public class PaymentConfigaration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(nameof(Payment));
        builder.HasKey(p => p.Id);
        builder.Property(p=>p.TransId).HasMaxLength(120).IsRequired();
        builder.Property(p=>p.Email).HasMaxLength(120).IsRequired();
        builder.Property(p=>p.IsPaymentConfirm).HasMaxLength(120).IsRequired();
        builder.Property(p=>p.CartItems).HasMaxLength(120).IsRequired();
        builder.Property(p=>p.OrderTime).HasMaxLength(120).IsRequired();
    }
}
