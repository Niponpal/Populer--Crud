using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration
{
    public class AdminConfigaration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable(nameof(Admin));
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserName).HasMaxLength(128).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(128).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(128).IsRequired();
        }
    }
}
