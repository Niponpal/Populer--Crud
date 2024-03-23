using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration;

public class SealesConfigaration : IEntityTypeConfiguration<SealesOwners>
{
    public void Configure(EntityTypeBuilder<SealesOwners> builder)
    {
        builder.ToTable(nameof(SealesOwners));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired ();
        builder.Property(x => x.Email).HasMaxLength(128).IsRequired ();
        builder.Property(x => x.Phone).HasMaxLength(128).IsRequired ();
        
    }
}
