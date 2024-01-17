using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.ProductName).HasColumnType("VARCHAR(100)").IsRequired();
            builder.HasOne(p => p.User)
                .WithMany(u => u.Orders)
                .HasPrincipalKey(u => u.Id);
        }
    }
}
