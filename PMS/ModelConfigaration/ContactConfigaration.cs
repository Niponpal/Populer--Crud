using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration
{
    public class ContactConfigaration : IEntityTypeConfiguration<Contaact>
    {
        public void Configure(EntityTypeBuilder<Contaact> builder)
        {
           builder.ToTable(nameof(Contaact));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TextArea).HasMaxLength(50).IsRequired();
        }
    }
}
