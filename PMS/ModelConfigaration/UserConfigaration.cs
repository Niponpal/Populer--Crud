using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Models;

namespace PMS.ModelConfigaration
{
    public class UserConfigaration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(120).IsRequired();
            builder.Property(x => x.EMail).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(120).IsRequired();
        }
    }
}
