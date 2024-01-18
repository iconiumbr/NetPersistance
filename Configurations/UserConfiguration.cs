using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SystemUser");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("Varchar(50)");
            builder.Property(u => u.Password).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(u => u.UserName).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(u=> u.Permission).HasConversion<int>().HasColumnType("int").IsRequired();
            builder.HasMany(u => u.Orders)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
