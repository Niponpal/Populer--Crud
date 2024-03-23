using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration;

public class PopularConfigaration : IEntityTypeConfiguration<Popular>
{
    public void Configure(EntityTypeBuilder<Popular> builder)
    {
       builder.ToTable(nameof(Popular));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.Property(x => x.SrlNO).HasMaxLength(120).IsRequired();
        builder.Property(x => x.ProductCode).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Image1).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Image2).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Image3).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Location).HasMaxLength(120).IsRequired();
        builder.Property(x => x.GoogleMap).HasMaxLength(120).IsRequired();
        builder.Property(x => x.SomeDetail).HasMaxLength(120).IsRequired();
        builder.Property(x => x.MoreDetail).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Price).HasMaxLength(120).IsRequired();

    }
}
